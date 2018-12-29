using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore.Internal;
using Org.BouncyCastle.Crypto.Agreement.Srp;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.OpenSsl;
using Remotion.Linq.Clauses;

namespace WebApp1.Models
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryPath { get; set; }
        public PaginationViewModel<Productwaarde> Products { get; set; }
        public List<Productsoort> Categories { get; set; }
        // Index 0 = attribute name, Index 1 = attribute id
        public List<string[]> Attributes { get; set; }
        public CategoryFilterModel Filters { get; set; }
        
        // The fields below are used to display the correct filter options
        public string[] PriceFilterRange { get; set; }
        public string[] QuantityFilterRange { get; set; }
    }

    // Model is used to group the filter parameters
    // that is passed to the controller by the form into one model
    public class CategoryFilterModel
    {
        // Model will be expanded as more filter options are added
        public string[] PriceRanges { get; set; }
        public string[] QuantityRanges { get; set; }
        public List<AttributeFilter> AttributeFilters { get; set; }
        // Used to check if Filter options are empty!
        public bool IsEmpty
        {
            // Check if all fields of this model are null
            get
            {
                bool emptyPrice = PriceRanges == null && QuantityRanges == null;
                bool empty = true;
                if (AttributeFilters != null)
                {
                    foreach (var item in AttributeFilters)
                    {
                        if (item.FilterValue != null)
                        {
                            empty = false;
                        }
                    }
                }
                else
                {
                    empty = true;
                }
                return empty && emptyPrice;
            }
        }
    }

    public class AttributeFilter
    {
        public int AttributeId { get; set; }
        public string FilterValue { get; set; }
    }
    
    public class CategoryViewModelHelper
    {
        private readonly WebshopContext context;
        private readonly int maxPageSize;

        public CategoryViewModelHelper(int maxPageSize, WebshopContext context)
        {
            this.context = context;
            this.maxPageSize = maxPageSize;
        }
        
        public CategoryViewModel CreateViewModel(int? categoryId, int pageNumber, CategoryFilterModel filters = null)
        {
            CategoryViewModel viewModel = new CategoryViewModel();
            PaginationHelper<Productwaarde> productsPage = new PaginationHelper<Productwaarde>(maxPageSize,context.Productwaarde);
            
            // If no id was provided, we will display all products
            if (categoryId == null)
            {
                categoryId = GetRootParentId();
            }
            
            // Get list of categories where we have to retrieve products from
            List<int> categoryIdList = GetProductCategoryIds((int)categoryId);
            
            viewModel.CategoryName =
                (from ps in context.Productsoort where ps.Id == categoryId select ps.Naam).FirstOrDefault();
            
            // Retrieve all products that belong to one of the categories
            IQueryable<Productwaarde> productsQuery =
            (
                from pw in context.Productwaarde
                where categoryIdList.Contains(pw.ProductsoortId)
                select pw
            );
            
            viewModel.PriceFilterRange = GetPriceFilterRange(productsQuery);
            viewModel.QuantityFilterRange = GetQuantityFilterRange(productsQuery);
            
            // Apply filters if controller provided us with one
            productsQuery = FilterAttributes(filters, productsQuery);
            productsQuery = FilterPrice(filters, productsQuery);
            productsQuery = FilterQuantity(filters, productsQuery);
                
            viewModel.Filters = filters;
            viewModel.Products = productsPage.GetPageIQueryable(pageNumber, productsQuery);
            
            // Get the attributes of that category
            List<string[]> attributes = new List<string[]>();
            var att =
                (from atts in context.Attribuutsoort where atts.ProductsoortId == categoryId select atts).ToList();
            
            // And place that data into an 2D array
            // Each element is an array that contains Attribute name and ID
            foreach (var attribute in att)
            {
                attributes.Add(new []{attribute.Attrbuut, attribute.Id.ToString()});
            }

            
            // Populate the view model with the needed data
            viewModel.Attributes = attributes;            
            viewModel.Categories =
            (
                from ps in context.Productsoort
                from pc in context.ParentChild
                where pc.ParentId == categoryId &&
                      ps.Id == pc.ChildId
                select ps
            ).ToList();

            viewModel.CategoryPath = BuildCategoryPath((int)categoryId);
            viewModel.CategoryId = (int)categoryId;
            
            return viewModel;
        }

        /// <summary>
        /// Get the root category, meaning the category that is at the top.
        /// This category is the main parent of all categories
        /// </summary>
        /// <returns>ID of the root category</returns>
        public int GetRootParentId()
        {
            return
            (
                from r in context.ParentChild
                where 
                !(
                    from c in context.ParentChild 
                    select c.ChildId
                ).Contains(r.ParentId)
                select r.ParentId
            ).FirstOrDefault();
        }
        
        public string BuildCategoryPath(int id)
        {
            int parentId;
            Productsoort category = (from ps in context.Productsoort where ps.Id == id select ps).FirstOrDefault();

            IQueryable<int> query =
            (
                from pc in context.ParentChild
                where pc.ChildId == category.Id
                select pc.ParentId
            );

            if (query.Any())
            {
                parentId = query.FirstOrDefault();
            }
            else
            {
                string name = (from ps in context.Productsoort where ps.Id == GetRootParentId() select ps.Naam).FirstOrDefault();
                return name;
            }

            string res = BuildCategoryPath(parentId) + " > " + category.Naam;
            return res;
        }

        private string[] GetPriceFilterRange(IQueryable<Productwaarde> query)
        {
            string[] ranges = new string[5];
            double maxPrice = (from pw in query select pw.Price).Max();
            var maxDiscountPriceQuery =
                (from pw in query where pw.DiscountedPrice != -1 select pw.DiscountedPrice);

            if (maxDiscountPriceQuery.Any())
            {
                double maxDiscountPrice = maxDiscountPriceQuery.Max();
                if (maxDiscountPrice > maxPrice)
                {
                    maxPrice = maxDiscountPrice;
                }
            }

            double rangeIncr = maxPrice / 5;
            for (int i = 0; i <= ranges.Length-1; i++)
            {
                ranges[i] = $"€{rangeIncr * i} - €{rangeIncr * (i + 1)}";
            }

            return ranges;
        }

        private string[] GetQuantityFilterRange(IQueryable<Productwaarde> query)
        {
            string[] ranges = new string[5];
            int maxQuantity = (from pw in query select pw.Quantity).Max();
            int rangeIncr = maxQuantity / 5;
            for (int i = 0; i <= ranges.Length - 1; i++)
            {
                ranges[i] = string.Format("{0} stukken - {1} stukken", rangeIncr * i, rangeIncr * (i+1));
            }

            return ranges;
        }

        private List<int> GetProductCategoryIds(int id)
        {
            List<int> idArray = new List<int>();
            idArray.Add(id);
            int[] subCount =
            (
                from pc in context.ParentChild
                where pc.ParentId == id
                select pc.ChildId
            ).ToArray();

                     
            foreach (int subId in subCount)
            {
                var list = GetProductCategoryIds(subId);
                foreach (int item in list)
                {
                    idArray.Add(item);
                }
            }

            return idArray;
        }
        
        /// <summary>
        /// Converts a price range string (e.g. "€500 - €2999")
        /// and extracts the two numbers from it which will be placed in a double array
        /// </summary>
        /// <param name="range">The range string</param>
        /// <returns>A double array that contains the minimum/maximum price</returns>
        private double[] GetMinMaxPrice(string range)
        {
            double[] rangeArray = new double[2];
            range = range.Replace("€", string.Empty).Replace(" ", string.Empty);
            string[] split = range.Split("-");
            rangeArray[0] = double.Parse(split[0]);
            rangeArray[1] = double.Parse(split[1]);
            
            // Make sure index 0 is min and index 1 is max
            if (rangeArray[0] > rangeArray[1])
            {
                double min = rangeArray[1];
                double max = rangeArray[0];
                rangeArray[0] = min;
                rangeArray[1] = max;
            }
            
            return rangeArray;
        }

        private int[] GetQuantityRangeFromString(string range)
        {
            int[] rangeArray = new int[2];
            range = range.Replace("stukken", string.Empty).Replace(" ", string.Empty);
            string[] split = range.Split("-");
            rangeArray[0] = int.Parse(split[0]);
            rangeArray[1] = int.Parse(split[1]);
            
            // Make sure index 0 is min and index 1 is max
            if (rangeArray[0] > rangeArray[1])
            {
                int min = rangeArray[1];
                int max = rangeArray[0];
                rangeArray[0] = min;
                rangeArray[1] = max;
            }

            return rangeArray;
        }

        private IQueryable<Productwaarde> FilterPrice(CategoryFilterModel filters, IQueryable<Productwaarde> query)
        {
            // Error check
            if (filters == null) return query;
            if (filters.PriceRanges == null)
            {
                filters.PriceRanges = new string[0];
                return query;
            }
            
            bool filtered = false;
            var filteredQuery = query.Take(0);
            foreach (string item in filters.PriceRanges)
            {
                if (item.ToUpper() != "FALSE")
                {
                    // This bool is used to check if we indeed did filtering 
                    filtered = true;

                    // Get the price range that is used in the filter
                    double[] range = GetMinMaxPrice(item);

                    // First we check the products with discount
                    var discountQuery =
                        from p in query
                        where p.DiscountedPrice != -1 &&
                              p.DiscountedPrice >= range[0] &&
                              p.DiscountedPrice <= range[1]
                        select p;

                    // Now we check the products that aren't in discount!
                    // Savvy?
                    filteredQuery = filteredQuery.Union(
                        (
                            from p in query
                            where p.DiscountedPrice == -1 &&
                                  p.Price >= range[0] &&
                                  p.Price <= range[1]
                            select p
                        ).Union(discountQuery)
                    );
                }
            }
            
            if (filtered) return filteredQuery;
            return query;
        }

        private IQueryable<Productwaarde> FilterQuantity(CategoryFilterModel filters, IQueryable<Productwaarde> query)
        {
            // Error check
            if (filters == null) return query;
            if (filters.QuantityRanges == null)
            {
                filters.QuantityRanges = new string[0];
                return query;
            }
            
            bool filtered = false;
            var filteredQuery = query.Take(0);
            foreach (string item in filters.QuantityRanges)
            {
                if (item.ToUpper() != "FALSE")
                {
                    // This bool is used to check if we indeed did filtering 
                    filtered = true;
                            
                    // Get the price range that is used in the filter
                    int[] range = GetQuantityRangeFromString(item);

                    // Now we check the products that match the filter requirement
                    filteredQuery = filteredQuery.Union(
                        from p in query
                        where p.Quantity >= range[0] &&
                              p.Quantity <= range[1]
                        select p
                    );
                }
            }
            
            if (filtered) return filteredQuery;
            return query;
        }
        
        private IQueryable<Productwaarde> FilterAttributes(CategoryFilterModel filters, IQueryable<Productwaarde> query)
        {
            if (filters == null) return query;
            if (filters.AttributeFilters == null) return query;
            
            bool filtered = false;
            var filteredQuery = query.Take(0);
            foreach (AttributeFilter item in filters.AttributeFilters)
            {
                if (item.FilterValue != null)
                {
                    filtered = true;
                    filteredQuery = filteredQuery.Union(
                        from attw in context.Attribuutwaarde
                        from pw in query
                        where attw.ProductwaardeId == pw.Id &&
                              attw.AttribuutsoortId == item.AttributeId &&
                              attw.Waarde.ToUpper().Contains(item.FilterValue.ToUpper())
                        select pw
                    );
                }
            }

            if (filtered) return filteredQuery;
            return query;
        }
    }
}