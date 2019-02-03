using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using WebApp1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using NuGet.Frameworks;
using WebApp1.Models.Database;

namespace WebApp1.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("/Admin/[controller]/")]
    public class EditProductController : Controller
    {
        private readonly WebshopContext context;
        private readonly IHostingEnvironment appEnvironment;

        public enum ResultMsg
        {
            Success,
            Failed,
            None
        }

        public EditProductController(WebshopContext context, IHostingEnvironment appEnvironment)
        {
            this.context = context;
            this.appEnvironment = appEnvironment;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index(int? id, ResultMsg msg = ResultMsg.None)
        {
            if (id == null) return NotFound();

            var query =
                from pw in context.Product
                where pw.Id == id
                select new EditProductViewModel
                {
                    Id = pw.Id,
                    Title = pw.Title,
                    Price = pw.Price.ToString(new CultureInfo("nl-NL")),
                    DiscountedPrice = pw.DiscountedPrice.ToString(new CultureInfo("nl-NL")),
                    Image = pw.Image,
                    Quantity = pw.Quantity,
                    Description = pw.Description,
                    ProductsoortId = pw.CategoryId
                };

            if (!query.Any()) return NotFound();

            EditProductViewModel viewModel = query.FirstOrDefault();

            viewModel.NumberAttributes = (
                from atts in context.AttributeType
                from attw in context.AttributeValue
                where atts.CategoryId == viewModel.ProductsoortId &&
                      attw.AttributeTypeId == atts.Id &&
                      attw.ProductId == viewModel.Id &&
                      atts.Type == "number"
                select new NumberAttributeModel
                {
                    AttributeNameId = atts.Id,
                    AttributeName = atts.Name,
                    AttributeValueId = attw.Id,
                    AttributeValue = attw.Waarde,
                }
            ).ToList();

            viewModel.StringAttributes = (
                from atts in context.AttributeType
                from attw in context.AttributeValue
                where atts.CategoryId == viewModel.ProductsoortId &&
                      attw.AttributeTypeId == atts.Id &&
                      attw.ProductId == viewModel.Id &&
                      atts.Type == "string"
                select new StringAttributeModel
                {
                    AttributeNameId = atts.Id,
                    AttributeName = atts.Name,
                    AttributeValueId = attw.Id,
                    AttributeValue = attw.Waarde,
                }
            ).ToList();

            viewModel.ResultMsg = msg;
            return View(viewModel);
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit(EditProductViewModel viewModel, IFormFile img)
        {
            try
            {
                // Get the current values of the produt in db and update it.
                Product productModel =
                    (from pw in context.Product where pw.Id == viewModel.Id select pw).FirstOrDefault();

                if (productModel == null)
                {
                    return StatusCode(500);
                }

                productModel.Title = viewModel.Title;
                productModel.Price = double.Parse(viewModel.Price);
                productModel.Quantity = viewModel.Quantity;
                if (!string.IsNullOrWhiteSpace(viewModel.Description))
                {
                    productModel.Description = viewModel.Description;
                }

                if (viewModel.UseDiscount)
                {
                    productModel.DiscountedPrice = double.Parse(viewModel.DiscountedPrice);
                }
                else
                {
                    // Setting discount price to -1 disabled it!
                    productModel.DiscountedPrice = -1;
                }

                // Update attributes
                foreach (var numberAttribute in viewModel.NumberAttributes)
                {
                    AttributeValue attribute =
                        (from attw in context.AttributeValue where attw.Id == numberAttribute.AttributeValueId select attw)
                        .FirstOrDefault();


                    attribute.Waarde = numberAttribute.AttributeValue;
                }
                foreach (var stringAttribute in viewModel.StringAttributes)
                {
                    AttributeValue attribute =
                        (from attw in context.AttributeValue where attw.Id == stringAttribute.AttributeValueId select attw)
                        .FirstOrDefault();


                    attribute.Waarde = stringAttribute.AttributeValue;
                }


                if (img != null && img.Length > 0)
                {
                    var file = img;
                    var uploads = Path.Combine(appEnvironment.WebRootPath,
                        "images" + Path.DirectorySeparatorChar + "products");
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
                    if (viewModel.Image != null)
                    {
                        if (System.IO.File.Exists(Path.Combine(uploads, viewModel.Image)) &&
                            viewModel.Image != "default.png")
                        {
                            System.IO.File.Delete(Path.Combine(uploads, viewModel.Image));
                        }
                    }
                }

                context.SaveChanges();
                return RedirectToAction("Index", "EditProduct", new {id = viewModel.Id, msg = ResultMsg.Success});
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured whilst editing a product (ID={0}) {1}{2}", viewModel.Id,
                    Environment.NewLine, e.Message);
                return RedirectToAction("Index", "EditProduct", new {id = viewModel.Id, msg = ResultMsg.Failed});
            }
        }
    }
}