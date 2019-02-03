using System.Collections.Generic;
using System.Linq;
using WebApp1.Models.Database;
using WebApp1.Models.ViewModels;

namespace WebApp1.Models.Helper
{
    public class CategoryListViewModelHelper
    {
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