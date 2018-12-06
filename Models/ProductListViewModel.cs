using System.Collections.Generic;
using System.Linq;
using WebApp1.Models;

namespace WebApp1.Models
{
    public class ProductListViewModel
    {
        // JSON
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double DiscountedPrice { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
    }

    public class CategoryListViewModel
    {
        // JSON
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductCount { get; set; }
        public int AttributeCount { get; set; }
    }

    public class ProductListViewModelHelper
    {
        public PaginationViewModel<ProductListViewModel> ConvertToViewModel(WebshopContext context, PaginationViewModel<Productwaarde> productPage)
        {
            PaginationViewModel<ProductListViewModel> model = new PaginationViewModel<ProductListViewModel>
            {
                PageNumber = productPage.PageNumber,
                PageSize = productPage.PageSize,
                TotalPages = productPage.TotalPages,
                Data = new List<ProductListViewModel>()
            };

            foreach (Productwaarde item in productPage.Data)
            {
                ProductListViewModel viewModel = new ProductListViewModel
                {
                    Id = item.Id, 
                    Name = item.Title,
                    Price = item.Price,
                    DiscountedPrice = item.DiscountedPrice,
                    Quantity = item.Quantity,
                    Category = 
                    (
                        from ps in context.Productsoort
                        where ps.Id == item.ProductsoortId
                        select ps.Naam
                    ).FirstOrDefault()
                };
                model.Data.Add(viewModel);
            }

            return model;
        }

        public PaginationViewModel<CategoryListViewModel> ConvertToCategoryViewModel(WebshopContext context,
            PaginationViewModel<Productsoort> productCategory)
        {
            PaginationViewModel<CategoryListViewModel> model = new PaginationViewModel<CategoryListViewModel>
            {
                PageNumber = productCategory.PageNumber,
                PageSize = productCategory.PageSize,
                TotalPages = productCategory.TotalPages,
                Data = new List<CategoryListViewModel>()
            };

            foreach (Productsoort item in productCategory.Data)
            {
                CategoryListViewModel viewModel = new CategoryListViewModel
                {
                    Id = item.Id,
                    Name = item.Naam,
                    ProductCount =
                    (
                        from pw in context.Productwaarde
                        where pw.ProductsoortId == item.Id
                        select pw.Id
                    ).Count(),
                    AttributeCount =
                    (
                        from atts in context.Attribuutsoort
                        where atts.ProductsoortId == item.Id
                        select atts.Attrbuut
                    ).Count()
                };
                model.Data.Add(viewModel);
            }
            
            return model;
        }
    }
}