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