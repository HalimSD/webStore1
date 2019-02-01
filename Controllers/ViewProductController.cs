using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Identity;
using WebApp1.Models;
using Microsoft.AspNetCore.Mvc;
using WebApp1.Models.Database;

namespace klaas.Controllers
{
    public class ViewProductController : Controller
    {
        private readonly WebshopContext context;
        private readonly UserManager<Users> userManager;
        
        public ViewProductController(WebshopContext context, UserManager<Users> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        
        // GET
        public IActionResult Index(int? id)
        {
            // Check if product was found
            // Else return 404 error
            if (id == null) return NotFound();
            
            Product product = (from pw in context.Product where pw.Id == id select pw).FirstOrDefault();
            if (product == null) return NotFound();
            
            Category category =(from ps in context.Category where ps.Id == product.CategoryId select ps).FirstOrDefault();           
            List<ViewProductAttributes> attributes = 
                (from a in context.AttributeValue
                join pwaarde in context.Product on a.ProductId equals pwaarde.Id
                join at in context.AttributeType on a.AttributeTypeId equals at.Id
                where pwaarde.Id == product.Id
                 select new ViewProductAttributes
                          {
                              AttributeName = at.Name,
                              AttributeValue = a.Waarde
                      
                                  
                          }).ToList();
            
            // Check if productsoort was found
            // Else return 404 error
            if (category == null)
            {
                return StatusCode(404);
            };
            
            // Build the model that will be passed to the view
            ViewProductModel productViewModel = new ViewProductModel();
            productViewModel.Id = product.Id;
            productViewModel.Name = product.Title;
            productViewModel.Price = "€ " + product.Price.ToString();
            productViewModel.Category = category.Naam;
            productViewModel.Image = product.Image;
            productViewModel.Description = product.Description;
            productViewModel.Quantity = product.Quantity;
            productViewModel.CategoryPath = new CategoryViewModelHelper(0, context).BuildCategoryPath(category.Id);
            if (product.DiscountedPrice == -1)
            {
                productViewModel.DiscountedPrice = "-1";
            }
            else
            {
                productViewModel.DiscountedPrice = "€ " + product.DiscountedPrice.ToString();
            }

            
            // If product is already within user's favorites then skip it
            int count = 
                (from f in context.Favorite
                    where f.ProductId == product.Id && f.UserId == userManager.GetUserId(User)
                    select f).Count();
            
            if (count > 0) { ViewBag.alreadyInFav = true; }
            else { ViewBag.alreadyInFav = false; }
            
            ViewData["ProductModel"] = product;
            ViewData["ProductAttributeModel"] = attributes;
            return View();
        }
    }
}
