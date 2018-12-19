using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Identity;
using WebApp1.Models;
using Microsoft.AspNetCore.Mvc;

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
            
            Productwaarde productwaarde = (from pw in context.Productwaarde where pw.Id == id select pw).FirstOrDefault();
            if (productwaarde == null) return NotFound();
            
            Productsoort productsoort =(from ps in context.Productsoort where ps.Id == productwaarde.ProductsoortId select ps).FirstOrDefault();           
            List<ViewProductAttributes> attributes = 
                (from a in context.Attribuutwaarde
                join pwaarde in context.Productwaarde on a.ProductwaardeId equals pwaarde.Id
                join at in context.Attribuutsoort on a.AttribuutsoortId equals at.Id
                where pwaarde.Id == productwaarde.Id
                 select new ViewProductAttributes
                          {
                              AttributeName = at.Attrbuut,
                              AttributeValue = a.Waarde
                      
                                  
                          }).ToList();
            
            // Check if productsoort was found
            // Else return 404 error
            if (productsoort == null)
            {
                return StatusCode(404);
            };
            
            // Build the model that will be passed to the view
            ViewProductModel product = new ViewProductModel();
            product.Id = productwaarde.Id;
            product.Name = productwaarde.Title;
            product.Price = "€ " + productwaarde.Price.ToString();
            product.Category = productsoort.Naam;
            product.Image = productwaarde.Image;
            product.Description = productwaarde.Description;
            product.Quantity = productwaarde.Quantity;
            product.CategoryPath = new CategoryViewModelHelper(0, context).BuildCategoryPath(productsoort.Id);
            if (productwaarde.DiscountedPrice == -1)
            {
                product.DiscountedPrice = "-1";
            }
            else
            {
                product.DiscountedPrice = "€ " + productwaarde.DiscountedPrice.ToString();
            }

            
            // If product is already within user's favorites then skip it
            int count = 
                (from f in context.Favorites
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
