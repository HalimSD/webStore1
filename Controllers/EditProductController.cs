using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using WebApp1.Models;
using WebApp1.products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using NuGet.Frameworks;

namespace WebApp1.Controllers
{
    [Route("/admin/[controller]/")]
    public class EditProductController : Controller
    {
        private readonly WebshopContext context;
        private readonly IHostingEnvironment appEnvironment;

        public EditProductController(WebshopContext context, IHostingEnvironment appEnvironment)
        {
            this.context = context;
            this.appEnvironment = appEnvironment;
        }
        
        [Route("")]
        [Route("Index")]
        public IActionResult Index(int id)
        {
            Productwaarde product = (from pw in context.Productwaarde where pw.Id == id select pw).FirstOrDefault();           
            if (product == null)
            {
                return StatusCode(404);
            }

            List<ViewProductAttributes> attributes = (
                from atts in context.Attribuutsoort
                from attw in context.Attribuutwaarde
                where atts.ProductsoortId == product.ProductsoortId
                where attw.AttribuutsoortId == atts.Id
                where attw.ProductwaardeId == product.Id
                select new ViewProductAttributes
                {
                    AttributeNameId = atts.Id,
                    AttributeName = atts.Attrbuut,
                    AttributeValueId = attw.Id,
                    AttributeValue = attw.Waarde
                }
            ).ToList();

            ViewBag.EditProduct = product;
            ViewBag.EditProductAttributes = attributes;
            return View();
        }
        
        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit(Productwaarde product, int attributeCount, IFormFile img)
        {            
            // Get all the attributes and update the database with the new values
            List<ViewProductAttributes> attributes = new List<ViewProductAttributes>();
            for (int i = 0; i <= attributeCount - 1; i++)
            {
                //int id = int.Parse(Request.Query["attributeId" + i].ToString());
                int id = int.Parse(Request.Form["attributeId" + i]);
                string value = Request.Form["attributeValue" + i];

                Attribuutwaarde attribute =
                    (from attw in context.Attribuutwaarde where attw.Id == id select attw)
                    .FirstOrDefault();

                attribute.Waarde = value;           
            }
            
            // Get the current values of the produt in db and update it.
            Productwaarde productModel =
                (from pw in context.Productwaarde where pw.Id == product.Id select pw).FirstOrDefault();

            if (productModel == null) { return StatusCode(500); }

            productModel.Title = product.Title;
            productModel.Price = product.Price;
            productModel.Quantity = product.Quantity;
            if (!string.IsNullOrWhiteSpace(product.Description))
            {
                productModel.Description = product.Description;
            }
            
            if (img != null && img.Length > 0)
            {
                var file = img;
                var uploads = Path.Combine(appEnvironment.WebRootPath, "images" + Path.DirectorySeparatorChar + "products");
                if (file.Length > 0)
                {
                    // Create filename that is a unique guid
                    var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                    {
                        // Upload to folder and update the image reference in db
                        file.CopyTo(fileStream);
                        productModel.Image = fileName;
                    }

                }
                // Delete old image
                if (System.IO.File.Exists(Path.Combine(uploads, product.Image)))
                {
                    System.IO.File.Delete(Path.Combine(uploads, product.Image));
                }                  
            }
            
            context.SaveChanges();
            return RedirectToAction("Index", "EditProduct", new {id = product.Id});
        }
    }
}