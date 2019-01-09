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
        public List<string[]> CategoryPath { get; set; }
        public PaginationViewModel<Productwaarde> Products { get; set; }

        public List<Productsoort> Categories { get; set; }

        // Index 0 = name, Index 1 = id, Index 2 = type
        public List<AttributeFilter> Attributes { get; set; }
        public CategoryFilterModel Filters { get; set; }

        // The fields below are used to display the correct filter options
        public string[] PriceFilterRange { get; set; }
        public string[] QuantityFilterRange { get; set; }
        public bool IsFiltered { get; set; } = false;
    }

    // Model is used to group the filter parameters
    // that is passed to the controller by the form into one model
    public class CategoryFilterModel
    {
        // Model will be expanded as more filter options are added
        public string[] PriceRanges { get; set; }
        public string[] QuantityRanges { get; set; }

        public List<AttributeFilter> AttributeFilters { get; set; }

        public bool HasAttributeFilters
        {
            get
            {
                bool containsFilters = false;
                if (AttributeFilters == null) return false;
                foreach (AttributeFilter attributeFilter in AttributeFilters)
                {
                    if (attributeFilter.Type == "number")
                    {
                        if (attributeFilter.FilterRanges != null)
                        {
                            containsFilters = true;
                        }
                    }
                    if (attributeFilter.Type == "string")
                    {
                        if (!string.IsNullOrWhiteSpace(attributeFilter.FilterValue))
                        {
                            containsFilters = true;
                        }
                    }
                }

                return containsFilters;
            }
        }

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
                        if (item.Type == "string")
                        {
                            if (!string.IsNullOrEmpty(item.FilterValue)) empty = false;
                        }

                        if (item.Type == "number")
                        {
                            {
                                foreach (string range in item.FilterRanges)
                                {
                                    if (range != "false") empty = false;
                                }
                            }
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
        public string AttributeName { get; set; }
        public string[] FilterRanges { get; set; }
        public string Type { get; set; }
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
            PaginationHelper<Productwaarde> productsPage =
                new PaginationHelper<Productwaarde>(maxPageSize, context.Productwaarde);

            // If no id was provided, we will display all products
            if (categoryId == null)
            {
                categoryId = GetRootParentId();
                if (categoryId == -1) return null;
            }

            // Get list of categories where we have to retrieve products from
            List<int> categoryIdList = GetProductCategoryIds((int) categoryId);

            viewModel.CategoryName =
                (from ps in context.Productsoort where ps.Id == categoryId select ps.Naam).FirstOrDefault();

            // Retrieve all products that belong to one of the categories
            IQueryable<Productwaarde> productsQuery =
            (
                from pw in context.Productwaarde
                where categoryIdList.Contains(pw.ProductsoortId)
                select pw
            );
            
            // Get the attributes of that category 
            List<AttributeFilter> att =
                (from atts in context.Attribuutsoort
                    where atts.ProductsoortId == categoryId
                    select new AttributeFilter
                    {
                        AttributeName = atts.Attrbuut, AttributeId = atts.Id, Type = atts.Type
                    }).ToList();

            foreach (var attribute in att)
            {
                if (attribute.Type == "number")
                {
                    attribute.FilterRanges = GetNumberAttributeFilterRange(productsQuery, attribute.AttributeId);
                }
            }

            viewModel.PriceFilterRange = GetPriceFilterRange(productsQuery);
            viewModel.QuantityFilterRange = GetQuantityFilterRange(productsQuery);

            // Apply filters if controller provided us with one
            productsQuery = FilterAttributes(filters, productsQuery);
            productsQuery = FilterPrice(filters, productsQuery);
            productsQuery = FilterQuantity(filters, productsQuery);

            viewModel.Filters = filters;
            productsQuery = productsQuery.OrderBy(p => p.ProductsoortId);
            viewModel.Products = productsPage.GetPageIQueryable(pageNumber, productsQuery);

            // Populate the view model with the needed data
            viewModel.Attributes = att;
            viewModel.Categories =
            (
                from ps in context.Productsoort
                from pc in context.ParentChild
                where pc.ParentId == categoryId &&
                      ps.Id == pc.ChildId
                select ps
            ).ToList();

            viewModel.CategoryPath = BuildCategoryPath((int) categoryId);
            viewModel.CategoryId = (int) categoryId;

            return viewModel;
        }

        /// <summary>
        /// Get the root category, meaning the category that is at the top.
        /// This category is the main parent of all categories.
        /// If there is no ParentChild structure and there is only 1 category,
        /// then it will return that ID.
        ///
        /// If there is no ParentChild, but there is more than 2 categories (which shouldn't happen)
        /// then it will return -1
        /// </summary>
        /// <returns>Category ID</returns>
        public int GetRootParentId()
        {
            bool containsParentChildRows = (from pc in context.ParentChild select pc).Any();
            int containsCategoryRowCount = (from ps in context.Productsoort select ps).Count();
            if (!containsParentChildRows)
            {
                if (containsCategoryRowCount == 1)
                {
                    var res = (from ps in context.Productsoort select ps.Id).FirstOrDefault();
                    return res;
                }

                if (containsCategoryRowCount <= 0 || containsCategoryRowCount > 0)
                {
                    return -1;
                }
            }

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

        public List<string[]> BuildCategoryPath(int id, List<string[]> pathList = null)
        {
            int parentId;
            if (pathList == null)
            {
                pathList = new List<string[]>();
            }

            Productsoort category = (from ps in context.Productsoort where ps.Id == id select ps).FirstOrDefault();


            IQueryable<int> query =
                from pc in context.ParentChild
                where pc.ChildId == category.Id
                select pc.ParentId;

            if (query.Any())
            {
                parentId = query.FirstOrDefault();
                pathList.Add(new[] {category?.Id.ToString(), category?.Naam});
                BuildCategoryPath(parentId, pathList);
            }
            else
            {
                pathList.Add
                (
                    (
                        from ps in context.Productsoort
                        where ps.Id == GetRootParentId()
                        select new[]
                        {
                            ps.Id.ToString(),
                            ps.Naam
                        }
                    ).FirstOrDefault()
                );
            }

            return pathList;
        }

        private string[] GetPriceFilterRange(IQueryable<Productwaarde> query)
        {
            if (!query.Any()) return new string[5];

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
            for (int i = 0; i <= ranges.Length - 1; i++)
            {
                ranges[i] = $"€{rangeIncr * i} - €{rangeIncr * (i + 1)}";
            }

            return ranges;
        }

        private string[] GetQuantityFilterRange(IQueryable<Productwaarde> query)
        {
            if (!query.Any()) return new string[5];

            string[] ranges = new string[5];
            int maxQuantity = (from pw in query select pw.Quantity).Max();
            int rangeIncr = maxQuantity / 5;
            for (int i = 0; i <= ranges.Length - 1; i++)
            {
                ranges[i] = string.Format("{0} stukken - {1} stukken", rangeIncr * i, rangeIncr * (i + 1));
            }

            return ranges;
        }

        private string[] GetNumberAttributeFilterRange(IQueryable<Productwaarde> query, int attributeId)
        {
            if (!query.Any()) return new string[0];

            int[] attributeValues =
            (
                from attw in context.Attribuutwaarde
                where attw.AttribuutsoortId == attributeId &&
                      attw.Waarde != "N/A"
                select int.Parse(attw.Waarde)
            ).ToArray();
            if (!attributeValues.Any()) return new string[0];

            // Detirmine how many ranges will be created
            // Max is 5
            int rangeOptions = attributeValues.Length;
            if (rangeOptions > 5) rangeOptions = 5;


            string[] ranges = new string[rangeOptions];
            double maxValue = attributeValues.Max();
            double minValue = attributeValues.Min();

            double rangeIncr = (maxValue - minValue) / rangeOptions;
            for (int i = 0; i <= ranges.Length - 1; i++)
            {
                ranges[i] = $"{(int) (minValue + (rangeIncr * i))} - {(int) (minValue + (rangeIncr * (i + 1)))}";
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

        private double[] GetRangeValuesFromString(string range)
        {
            double[] rangeArray = new double[2];
            range = range.Replace("stukken", string.Empty)
                .Replace("€", string.Empty)
                .Replace(" ", string.Empty);
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
                    double[] range = GetRangeValuesFromString(item);

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
                    double[] range = GetRangeValuesFromString(item);

                    // Now we check the products that match the filter requirement
                    filteredQuery = filteredQuery.Union(
                        from p in query
                        where p.Quantity >= (int) range[0] &&
                              p.Quantity <= (int) range[1]
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
            if (!filters.HasAttributeFilters) return query;

            bool filtered = false;
            var filteredQuery = query.Take(0);
            foreach (AttributeFilter item in filters.AttributeFilters)
            {
                if (item.FilterValue == null && item.FilterRanges == null) continue;
                switch (item.Type)
                {
                    case "number":
                        foreach (string range in item.FilterRanges)
                        {
                            if (range == "false") continue;
                            double[] rangeValues = GetRangeValuesFromString(range);
                            filteredQuery = filteredQuery.Union(
                                from attw in context.Attribuutwaarde
                                from pw in query
                                where attw.ProductwaardeId == pw.Id &&
                                      attw.AttribuutsoortId == item.AttributeId &&
                                      Convert.ToInt32(attw.Waarde) >= rangeValues[0] &&
                                      Convert.ToInt32(attw.Waarde) <= rangeValues[1]
                                select pw
                            );
                            filtered = true;
                        }

                        break;
                    default:
                        if (string.IsNullOrWhiteSpace(item.FilterValue)) continue;
                        filteredQuery = filteredQuery.Union(
                            from attw in context.Attribuutwaarde
                            from pw in query
                            where attw.ProductwaardeId == pw.Id &&
                                  attw.AttribuutsoortId == item.AttributeId &&
                                  attw.Waarde.ToUpper().Contains(item.FilterValue.ToUpper())
                            select pw
                        );
                        filtered = true;
                        break;
                }
            }

            if (filtered) return filteredQuery;
            return query;
        }
    }
}