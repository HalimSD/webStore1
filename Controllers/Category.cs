using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class Category : Controller
    {
        private readonly int maxPageSize = 9;
        private readonly WebshopContext context;
        private PaginationHelper<Productwaarde> paginationProductwaarde;
        
        public Category(WebshopContext context)
        {
            this.context = context;
            paginationProductwaarde = new PaginationHelper<Productwaarde>(maxPageSize, context.Productwaarde);
        }
        
        // GET
        public IActionResult Index(int? categoryId, int? pageNumber)
        {
            if (pageNumber == null)
            {
                pageNumber = 1;
            }

            var model = new CategoryViewModelHelper(maxPageSize, context).CreateViewModel(categoryId, (int) pageNumber);
            return View(model);
        }
        
        public IActionResult Filtered(int? categoryId, int? pageNumber, CategoryFilterModel filters)
        {
            if (pageNumber == null)
            {
                pageNumber = 1;
            }

            var model = new CategoryViewModelHelper(maxPageSize, context).CreateViewModel(categoryId, (int) pageNumber, filters);
            return View("Index", model);
        }

        public IActionResult Search(string search, int? pageNumber)
        {
            if (pageNumber == null)
            {
                pageNumber = 1;
            }
            
            var products = 
                from m in context.Productwaarde
                where m.Title.ToUpper().Contains(search.ToUpper())
                select m;

            if (!String.IsNullOrEmpty(search))
            {
                var query0 =
                    from productwaarde in context.Productwaarde
                    join atributen in context.Attribuutsoort on productwaarde.ProductsoortId equals atributen.ProductsoortId
                    where atributen.Attrbuut.Contains(search)
                    select productwaarde;

                var query1 =
                    from attributen in context.Attribuutwaarde
                    join productwaarde in context.Productwaarde on attributen.ProductwaardeId equals productwaarde.Id
                    join atribuut in context.Attribuutsoort on attributen.AttribuutsoortId equals atribuut.Id
                    where attributen.Waarde.Contains(search)
                    select productwaarde;

                products = products.Union(query0).Union(query1);
                var pagination = new PaginationHelper<Productwaarde>(maxPageSize, context.Productwaarde);
                var viewModel = new CategoryViewModel
                {
                    CategoryName = search,
                    Products = pagination.GetPageIQueryable((int) pageNumber, products)
                };
                
                return View(viewModel);
            }

            return RedirectToAction("Index", "Category");
        }
        
        public JsonResult GetCategories()
        {
            int parentId = (from ps in context.Productsoort where ps.RootParent select ps.Id).FirstOrDefault();
            List<List<string>> json =
            (
                from ps in context.Productsoort
                from pc in context.ParentChild
                where ps.RootParent == false
                where ps.Id == pc.ChildId
                where pc.ParentId == parentId
                select new List<string>
                {
                    ps.Naam,
                    ps.Id.ToString()
                }
            ).ToList();
            return new JsonResult(json);
        }
    }
}