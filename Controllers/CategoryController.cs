using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Org.BouncyCastle.Ocsp;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly int maxPageSize = 9;
        private readonly WebshopContext context;
        private CategoryViewModelHelper helper;
        
        public CategoryController(WebshopContext context)
        {
            this.context = context;
            helper = new CategoryViewModelHelper(maxPageSize,context);
        }
        
        // GET
        public IActionResult Index(int? categoryId, int? pageNumber)
        {
            if (pageNumber == null)
            {
                pageNumber = 1;
            }

            CategoryViewModel model = helper.CreateViewModel(categoryId, (int) pageNumber);
            return View(model);
        }
        
        public IActionResult Filtered(int? categoryId, int? pageNumber, CategoryFilterModel filters, List<string> AttributeArray = null)
        {
            string seperator = "!@#$%^&*";
            
            if (pageNumber == null)
            {
                pageNumber = 1;
            }

            if (Request.Method == "POST")
            {
                List<string> priceRanges = new List<string>();
                for (int i = 0; i <= 4; i++)
                {
                    if (Request.Form.ContainsKey("priceRange" + i))
                    {
                        priceRanges.Add(Request.Form["priceRange" + i]);
                    }
                }

                if (filters.PriceRanges == null && priceRanges.Any())
                {
                    filters.PriceRanges = priceRanges.ToArray();
                }
            }
            else
            {
                if (AttributeArray != null)
                {
                    filters.AttributeFilters = new List<AttributeFilter>();
                    foreach (var item in AttributeArray)
                    {
                        string[] split = item.Split(seperator);
                        if (split[1] == "")
                        {
                            split[1] = null;
                        }
                        filters.AttributeFilters.Add(new AttributeFilter
                        {
                            AttributeId = int.Parse(split[0]),
                            FilterValue = split[1]
                        });
                    }
                }
            }
            
            if (filters.isEmpty)
            {
                int? id = categoryId;
                return RedirectToAction("Index", "Category", new
                {
                    categoryId = id
                });
            }
            
            CategoryViewModel model = helper.CreateViewModel(categoryId, (int) pageNumber, filters);
            return View(model);
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
                    where atributen.Attrbuut.ToUpper().Contains(search.ToUpper())
                    select productwaarde;

                var query1 =
                    from attributen in context.Attribuutwaarde
                    join productwaarde in context.Productwaarde on attributen.ProductwaardeId equals productwaarde.Id
                    join atribuut in context.Attribuutsoort on attributen.AttribuutsoortId equals atribuut.Id
                    where attributen.Waarde.ToUpper().Contains(search.ToUpper())
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
            int parentId = helper.GetRootParentId();
            List<List<string>> json =
            (
                from ps in context.Productsoort
                from pc in context.ParentChild
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