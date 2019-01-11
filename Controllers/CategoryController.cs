using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Primitives;
using Org.BouncyCastle.Ocsp;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly int maxPageSize = 9;
        private readonly WebshopContext context;
        private readonly string sessionFiltersKey = "categoryFilters";
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

            HttpContext.Session.Remove(sessionFiltersKey);
            CategoryViewModel model = helper.CreateViewModel(categoryId, (int) pageNumber);
            if (model == null) return NotFound(); 
            return View(model);
        }
        
        public IActionResult Filtered(int? categoryId, int? pageNumber, CategoryFilterModel filters, bool useSessionFilters = false)
        {
            
            if (pageNumber == null)
            {
                pageNumber = 1;
            }
          
            if (useSessionFilters)
            {
                filters = HttpContext.Session.Get<CategoryFilterModel>(sessionFiltersKey);
            }
            else
            {
                if (HttpContext.Request.Query.ContainsKey("priceCheckbox"))
                {
                    filters.PriceRanges = HttpContext.Request.Query["priceCheckbox"].ToArray();
                }
                if (HttpContext.Request.Query.ContainsKey("quantityCheckbox"))
                {
                    filters.QuantityRanges = HttpContext.Request.Query["quantityCheckbox"].ToArray();
                } 
                
                // Retrieve the filter options for the number attributes
                // First we count how many relevant keys there are
                filters.AttributeFilters = new List<AttributeFilter>();
                foreach (string key in HttpContext.Request.Query.Keys)
                {
                    if (key.Contains("AttributeId"))
                    {
                        int index = int.Parse(key.Replace("AttributeId", String.Empty));
                        if (HttpContext.Request.Query.ContainsKey("AttributeCheckboxValue" + index))
                        {
                            AttributeFilter currentFilter = new AttributeFilter()
                            {
                                AttributeId = int.Parse(HttpContext.Request.Query["AttributeId" + index]),
                                FilterRanges = HttpContext.Request.Query["AttributeCheckboxValue" + index].ToArray(),
                                Type = "number"
                            };
                            filters.AttributeFilters.Add(currentFilter);
                        }

                        if (HttpContext.Request.Query.ContainsKey("AttributeInputValue" + index))
                        {
                            AttributeFilter currentFilter = new AttributeFilter()
                            {
                                AttributeId = int.Parse(HttpContext.Request.Query["AttributeId" + index]),
                                FilterValue = HttpContext.Request.Query["AttributeInputValue" + index],
                                Type = "string"
                            };
                            filters.AttributeFilters.Add(currentFilter);
                        }
                    }
                }
            }
            
            if (filters.IsEmpty)
            {
                int? id = categoryId;
                return RedirectToAction("Index", "Category", new
                {
                    categoryId = id
                });
            }
            
            CategoryViewModel model = helper.CreateViewModel(categoryId, (int) pageNumber, filters);
            if (model == null) return NotFound(); 
            HttpContext.Session.Set(sessionFiltersKey, model.Filters);
            model.IsFiltered = true;
            return View("Index", model);
        }

        /// <summary>
        /// Handles pagination requests
        /// if the user goes to a different page whilst there is filter data in session,
        /// it will redirect it to the Filtered action and force it to use those filters.
        /// Else it will simply redirect to Index action.
        /// </summary>
        /// <param name="id">ID value of the category</param>
        /// <param name="pageIndex">Number of the page that has to be loaded</param>
        /// <returns></returns>
        public IActionResult GotoPage(int? id, int? pageIndex)
        {
            if (id == null) return NotFound();
            if (pageIndex == null) return NotFound();
            
            CategoryFilterModel sessionFilter = HttpContext.Session.Get<CategoryFilterModel>(sessionFiltersKey);
            if (sessionFilter != null)
            {
                return RedirectToAction("Filtered", "Category", new
                {
                    categoryId = id,    
                    pageNumber = pageIndex,
                    useSessionFilters = true
                });
            }
            return RedirectToAction("Index", "Category", new
            {
                categoryId = id,
                pageNumber = pageIndex
            });
        }
      
        public IActionResult Search(string search, int? pageNumber)
        {
            if (pageNumber == null)
            {
                pageNumber = 1;
            }
            if(search == null){
                return RedirectToAction("Index","Home");
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
        
        /// <summary>
        /// This action is an API endpoint used by headerProductsDropDown.js
        /// to load the main categories in the header
        /// </summary>
        /// <returns>JSON result containing category name's and id's</returns>
        public JsonResult GetCategories()
        {
            int parentId = helper.GetRootParentId();
            if (parentId == -1) return new JsonResult(parentId);
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