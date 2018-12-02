using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;
using WebApp1.Products;

namespace WebApp1.Controllers.Admin
{
    [Authorize(Roles= "Admin")]
    [Route("/Admin/[controller]/")]
    public class CategoryList : Controller
    {
        private readonly WebshopContext context;
        private readonly int maxPageSize = 20;
        
        public CategoryList(WebshopContext context)
        {
            this.context = context;
        }
        
        
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
        
        [Route("ConfirmDelete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }           
            Productsoort category = context.Productsoort.FirstOrDefault(m => m.Id == id);            
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [Route("DeleteCategory")]
        public IActionResult DeleteCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Productsoort category = context.Productsoort.FirstOrDefault(m => m.Id == id); 
            if (category == null)
            {
                return NotFound();
            }
            context.Productsoort.Remove(category);
            context.SaveChanges();
            return RedirectToAction("Index", "CategoryList");
        }
        
        [Route("GetData")]
        public JsonResult GetData(int pageIndex=1)
        {
            // Create the PaginationHelper instance and use it to get the first page of productwaarde
            PaginationHelper<Productsoort> pagination = new PaginationHelper<Productsoort>(maxPageSize,context.Productsoort);
            PaginationViewModel<Productsoort> categoryPage = pagination.GetPage(pageIndex);
            
            // Since the default Productwaarde doesn't contain all of the needed info
            // We will create a new model that we will return
            PaginationViewModel<CategoryListViewModel> json =
                new ProductListViewModelHelper().ConvertToCategoryViewModel(context, categoryPage);
            
            return new JsonResult(json);
        }

        [Route("GetDataFiltered")]
        public JsonResult GetDataFiltered(string id="", string name="", string productCount="", string attributeCount="", int pageIndex=1)
        {
            // Create a PaginationHelper instance. It will be used to generate a page
            PaginationHelper<Productsoort> pagination = new PaginationHelper<Productsoort>(maxPageSize,context.Productsoort);
            
            // Some error checking as JS may give null values!
            if (id == null) { id = ""; }
            if (name == null) { name = ""; }
            if (productCount == null) { productCount = ""; }
            if (attributeCount == null) { attributeCount = ""; }

            // Since the pagination helper doesn't have built-in filtering,
            // we'll have to prepare a custom filtered query and pass it to the helper
            IQueryable<Productsoort> query =
                from ps in context.Productsoort
                where ps.Id.ToString().Contains(id) &&
                      ps.Naam.ToUpper().Contains(name.ToUpper()) &&
                      (
                          from atts in context.Attribuutsoort
                          where atts.ProductsoortId == ps.Id
                          select atts
                      ).Count().ToString().Contains(attributeCount) &&
                      (
                          from pw in context.Productwaarde
                          where pw.ProductsoortId == ps.Id
                          select pw
                      ).Count().ToString().Contains(productCount)
                select ps;
                      
                      

            // Generate pages from the custom query
            PaginationViewModel<Productsoort> categoryPage = pagination.GetPageIQueryable(pageIndex, query);
            
            // Since the default Productwaarde doesn't contain all of the needed info
            // We will create a new model that we will return
            PaginationViewModel<CategoryListViewModel> json =
                new ProductListViewModelHelper().ConvertToCategoryViewModel(context, categoryPage);
            
            // Encode to JSON and return it
            return new JsonResult(json);
        }
    }
}