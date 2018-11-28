using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApp1.products;

namespace WebApp1.Models
{
    public class ProductListViewModel
    {
        // JSON
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
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
    }
}