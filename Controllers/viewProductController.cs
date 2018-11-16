using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using WebApp1.Models;
using WebApp1.products;
using Microsoft.AspNetCore.Mvc;
using Npgsql.TypeHandling;

namespace klaas.Controllers
{
    public class ViewProductController : Controller
    {
        private readonly WebshopContext context;
        public ViewProductController(WebshopContext context)
        {
            this.context = context;
        }
        
        // GET
        public IActionResult Index(int id)
        {
            
            Productwaarde productwaarde = (from pw in context.Productwaarde where pw.Id == id select pw).FirstOrDefault();
            Productsoort productsoort =(from ps in context.Productsoort where ps.Id == productwaarde.ProductsoortId select ps).FirstOrDefault();
            List<ViewProductAttributes> attributes = (from atts in context.Attribuutsoort
                from attw in context.Attribuutwaarde
                where atts.ProductsoortId == productsoort.Id && atts.Id == attw.AttribuutsoortId
                select new ViewProductAttributes
                    {AttributeName = atts.Attrbuut, AttributeValue = attw.Waarde.ToString()}).ToList();
            
            // Check if product was found
            // Else return 404 error
            if (productwaarde == null)
            {
                return StatusCode(404);
            };
            
            // Build the model that will be passed to the view
            ViewProductModel product = new ViewProductModel();
            product.Name = productwaarde.Title;
            product.Price = "€" + productwaarde.Price.ToString();
            product.Category = productsoort.Naam;

            ViewData["ProductModel"] = product;
            ViewData["ProductAttributeModel"] = attributes;
            return View();
        }
    }
}
