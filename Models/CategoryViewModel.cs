using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using Org.BouncyCastle.Crypto.Agreement.Srp;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.OpenSsl;
using Remotion.Linq.Clauses;

namespace WebApp1.Models
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryPath { get; set; }
        public string[] PriceFilterRange { get; set; }
        public PaginationViewModel<Productwaarde> Products { get; set; }
        public List<Productsoort> Categories { get; set; }
        public CategoryFilterModel Filters { get; set; }
    }

    // Model is used to group the filter parameters
    // that is passed to the controller by the form into one model
    public class CategoryFilterModel
    {
        // Model will be expanded as more filter options are added
        public string[] PriceRanges { get; set; }
        // Used to check if Filter options are empty!
        public bool isEmpty
        {
            get
            {
                // Will be expanded as more filter options are added
                if (PriceRanges == null) return true;
                return false;
            }
        }
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

            if (categoryId == null)
            {
                categoryId = GetRootParentId();
            }

            viewModel.CategoryName =
                (from ps in context.Productsoort where ps.Id == categoryId select ps.Naam).FirstOrDefault();
            
            IQueryable<Productwaarde> productsQuery =
            (
                from pw in context.Productwaarde
                where pw.ProductsoortId == categoryId
                select pw
            );
           
            viewModel.PriceFilterRange = GetPriceFilterRange(productsQuery);
            
            
            // Apply filters if controller provided us with one
            if (filters != null)
            {
                var filteredQuery = productsQuery.Take(0);
                
                // Apply the price range filter
                foreach (string item in filters.PriceRanges)
                {
                    if (item.ToUpper() != "FALSE")
                    {
                        // Get the price range that is used in the filter
                        double[] range = GetMinMaxPrice(item);
                    
                        // First we check the products with discount
                        var discountQuery =
                            from p in productsQuery
                            where p.DiscountedPrice != -1 &&
                                  p.DiscountedPrice >= range[0] &&
                                  p.DiscountedPrice <= range[1]
                            select p;
                    
                        // Now we check the products that aren't in discount!
                        // Savvy?
                        filteredQuery = filteredQuery.Union(
                            (
                                from p in productsQuery
                                where p.DiscountedPrice == -1 &&
                                      p.Price >= range[0] &&
                                      p.Price <= range[1]
                                select p
                            ).Union(discountQuery)
                        );
                    }
                }

                productsQuery = filteredQuery;
                viewModel.Filters = filters;
            }
            
            viewModel.Products = productsPage.GetPageIQueryable(pageNumber, productsQuery);
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

        public int GetRootParentId()
        {
            return
            (
                from ps in context.Productsoort
                from pc in context.ParentChild
                where ps.Id != pc.ChildId && ps.Id == pc.ParentId
                select ps.Id
            ).FirstOrDefault();
        }
        
        private string BuildCategoryPath(int id)
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
                ranges[i] = string.Format("€{0} - €{1}", rangeIncr * i, rangeIncr * (i+1));
            }

            return ranges;
        }

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
    }
}