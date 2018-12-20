using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using WebApp1.Models;

namespace WebApp1.Controllers.Admin
{
    [Route("/Admin/[controller]/")]
    public class ProductListController : Controller
    {
        private readonly WebshopContext context;
        private readonly int maxPageSize = 20;
        
        public ProductListController(WebshopContext context)
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
            Productwaarde products = context.Productwaarde.FirstOrDefault(m => m.Id == id);            
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        [Route("DeleteProduct")]
        public IActionResult DeleteProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Productwaarde product = context.Productwaarde.FirstOrDefault(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            context.Productwaarde.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index", "ProductList");
        }
        
        [Route("GetData")]
        public JsonResult GetData(int pageIndex=1)
        {
            // Create the PaginationHelper instance and use it to get the first page of productwaarde
            PaginationHelper<Productwaarde> pagination = new PaginationHelper<Productwaarde>(maxPageSize,context.Productwaarde);
            PaginationViewModel<Productwaarde> productPage = pagination.GetPage(pageIndex);
            
            // Since the default Productwaarde doesn't contain all of the needed info
            // We will create a new model that we will return
            PaginationViewModel<ProductListViewModel> json =
                new ProductListViewModelHelper().ConvertToViewModel(context, productPage);
            
            return new JsonResult(json);
        }

        [Route("GetDataFiltered")]
        public JsonResult GetDataFiltered(string id="", string name="", string price="", string discountPrice="", string stock="", string category="", int pageIndex=1)
        {
            // Create a PaginationHelper instance. It will be used to generate a page
            PaginationHelper<Productwaarde> pagination = new PaginationHelper<Productwaarde>(maxPageSize,context.Productwaarde);
            
            // Some error checking as JS may give null values!
            if (id == null) { id = ""; }
            if (name == null) { name = ""; }
            if (price == null) { price = ""; }
            if (stock == null) { stock = ""; }
            if (category == null) { category = ""; }
            if (discountPrice == null) { discountPrice = ""; }

            // Since the pagination helper doesn't have built-in filtering,
            // we'll have to prepare a custom filtered query and pass it to the helper
            // First we do the string based filtering
            IQueryable<Productwaarde> query =
                from pw in context.Productwaarde
                from ps in context.Productsoort
                where pw.ProductsoortId == ps.Id &&
                      pw.Title.ToUpper().Contains(name.ToUpper()) &&
                      ps.Naam.ToUpper().Contains(category.ToUpper())
                select pw;
            
            // Do the number filters
            if (id != "")
            {
                query = from pw in query where pw.Id == int.Parse(id) select pw;
            }
            if (price != "")
            {
                query = from pw in query where pw.Price == double.Parse(price) select pw;
            }
            if (stock != "")
            {
                query = from pw in query where pw.Quantity == int.Parse(stock) select pw;
            }
            if (discountPrice != "")
            {
                query = from pw in query where pw.DiscountedPrice == double.Parse(discountPrice) select pw;
            }
            
            // Generate pages from the custom query
            PaginationViewModel<Productwaarde> productPage = pagination.GetPageIQueryable(pageIndex, query);
            
            // Since the default Productwaarde doesn't contain all of the needed info
            // We will create a new model that we will return
            PaginationViewModel<ProductListViewModel> json =
                new ProductListViewModelHelper().ConvertToViewModel(context, productPage);
            
            // Encode to JSON and return it
            return new JsonResult(json);
        }
    }

}