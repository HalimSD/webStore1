using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using WebApp1.Models.Database;

namespace WebApp1.Models.Helper
{
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
            PaginationHelper<Product> productsPage =
                new PaginationHelper<Product>(maxPageSize, context.Product);

            // If no id was provided, we will display all products
            if (categoryId == null)
            {
                categoryId = GetRootParentId();
                if (categoryId == -1) return null;
            }

            // Verify the ID provided is a valid ID
            bool idIsValid = (from ps in context.Category where ps.Id == categoryId select ps).Any();
            if (!idIsValid) return null;

            // Get list of categories where we have to retrieve products from
            List<int> categoryIdList = GetProductCategoryIds((int) categoryId);

            viewModel.CategoryName =
                (from ps in context.Category where ps.Id == categoryId select ps.Naam).FirstOrDefault();

            // Retrieve all products that belong to one of the categories
            IQueryable<Product> productsQuery =
            (
                from pw in context.Product
                where categoryIdList.Contains(pw.CategoryId)
                select pw
            );

            // Get the attributes of that category 
            List<AttributeFilter> att =
                (from atts in context.AttributeType
                    where atts.CategoryId == categoryId &&
                          atts.Custom == false
                    select new AttributeFilter
                    {
                        AttributeName = atts.Name, AttributeId = atts.Id, Type = atts.Type
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
            productsQuery = productsQuery.OrderBy(p => p.CategoryId);
            viewModel.Products = productsPage.GetPageIQueryable(pageNumber, productsQuery);

            // Populate the view model with the needed data
            viewModel.Attributes = att;
            viewModel.Categories =
            (
                from ps in context.Category
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
            int containsCategoryRowCount = (from ps in context.Category select ps).Count();
            if (!containsParentChildRows)
            {
                if (containsCategoryRowCount == 1)
                {
                    var res = (from ps in context.Category select ps.Id).FirstOrDefault();
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

            Category category = (from ps in context.Category where ps.Id == id select ps).FirstOrDefault();


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
                        from ps in context.Category
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

        private string[] GetPriceFilterRange(IQueryable<Product> query)
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

        private string[] GetQuantityFilterRange(IQueryable<Product> query)
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

        private string[] GetNumberAttributeFilterRange(IQueryable<Product> query, int attributeId)
        {
            if (!query.Any()) return new string[0];

            double[] attributeValues =
            (
                from attw in context.AttributeValue
                where attw.AttributeTypeId == attributeId &&
                      attw.Waarde != "N/A"
                select double.Parse(attw.Waarde, CultureInfo.InvariantCulture)
            ).ToArray();
            if (!attributeValues.Any()) return new string[0];

            // Determine how many ranges will be created
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

        private IQueryable<Product> FilterPrice(CategoryFilterModel filters, IQueryable<Product> query)
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

        private IQueryable<Product> FilterQuantity(CategoryFilterModel filters, IQueryable<Product> query)
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

        private IQueryable<Product> FilterAttributes(CategoryFilterModel filters, IQueryable<Product> query)
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
                                from attw in context.AttributeValue
                                from pw in query
                                where attw.ProductId == pw.Id &&
                                      attw.AttributeTypeId == item.AttributeId &&
                                      Convert.ToDouble(attw.Waarde) >= rangeValues[0] &&
                                      Convert.ToDouble(attw.Waarde) <= rangeValues[1]
                                select pw
                            );
                            filtered = true;
                        }

                        break;
                    default:
                        if (string.IsNullOrWhiteSpace(item.FilterValue)) continue;
                        filteredQuery = filteredQuery.Union(
                            from attw in context.AttributeValue
                            from pw in query
                            where attw.ProductId == pw.Id &&
                                  attw.AttributeTypeId == item.AttributeId &&
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