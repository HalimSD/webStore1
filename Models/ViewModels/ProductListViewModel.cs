using System.Collections.Generic;
using System.Linq;
using WebApp1.Models;
using WebApp1.Models.Database;
using WebApp1.Models.Helper;

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
        public PaginationViewModel<ProductListViewModel> ConvertToViewModel(WebshopContext context, PaginationViewModel<Product> productPage)
        {
            PaginationViewModel<ProductListViewModel> model = new PaginationViewModel<ProductListViewModel>
            {
                PageNumber = productPage.PageNumber,
                PageSize = productPage.PageSize,
                TotalPages = productPage.TotalPages,
                Data = new List<ProductListViewModel>()
            };

            foreach (Product item in productPage.Data)
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
                        from ps in context.Category
                        where ps.Id == item.CategoryId
                        select ps.Naam
                    ).FirstOrDefault()
                };
                model.Data.Add(viewModel);
            }

            return model;
        }

        public PaginationViewModel<CategoryListViewModel> ConvertToCategoryViewModel(WebshopContext context,
            PaginationViewModel<Category> productCategory)
        {
            PaginationViewModel<CategoryListViewModel> model = new PaginationViewModel<CategoryListViewModel>
            {
                PageNumber = productCategory.PageNumber,
                PageSize = productCategory.PageSize,
                TotalPages = productCategory.TotalPages,
                Data = new List<CategoryListViewModel>()
            };

            foreach (Category item in productCategory.Data)
            {
                CategoryListViewModel viewModel = new CategoryListViewModel
                {
                    Id = item.Id,
                    Name = item.Naam,
                    ProductCount =
                    (
                        from pw in context.Product
                        where pw.CategoryId == item.Id
                        select pw.Id
                    ).Count(),
                    AttributeCount =
                    (
                        from atts in context.AttributeType
                        where atts.CategoryId == item.Id
                        select atts.Name
                    ).Count()
                };
                model.Data.Add(viewModel);
            }
            
            return model;
        }
    }
}