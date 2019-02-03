using System.Collections.Generic;
using System.Linq;
using WebApp1.Models.Database;
using WebApp1.Models.ViewModels;

namespace WebApp1.Models.Helper
{
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
    }
}