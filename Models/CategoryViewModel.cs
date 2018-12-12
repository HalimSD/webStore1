using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;

namespace WebApp1.Models
{
    public class CategoryViewModel
    {
        public string CategoryName { get; set; }
        public string CategoryPath { get; set; }
        public PaginationViewModel<Productwaarde> Products { get; set; }
        public List<Productsoort> Categories { get; set; }
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
        
        public CategoryViewModel CreateViewModel(int? categoryId, int pageNumber)
        {
            CategoryViewModel viewModel = new CategoryViewModel();
            PaginationHelper<Productwaarde> productsPage = new PaginationHelper<Productwaarde>(maxPageSize,context.Productwaarde);

            if (categoryId == null)
            {
                categoryId = (from ps in context.Productsoort where ps.RootParent select ps.Id).FirstOrDefault();
            }

            viewModel.CategoryName =
                (from ps in context.Productsoort where ps.Id == categoryId select ps.Naam).FirstOrDefault();
            
            IQueryable<Productwaarde> productsQuery =
            (
                from pw in context.Productwaarde
                from pc in context.ParentChild
                where pw.ProductsoortId == categoryId ||
                      (pw.ProductsoortId == pc.ChildId && pc.ParentId == categoryId)
                select pw
            );

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
            
            return viewModel;
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
                string name = (from ps in context.Productsoort where ps.RootParent select ps.Naam).FirstOrDefault();
                return name;
            }

            string res = BuildCategoryPath(parentId) + " > " + category.Naam;
            return res;
        }
    }
}