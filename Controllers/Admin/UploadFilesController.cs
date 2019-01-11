using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;
using System;
using Csv;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;

namespace Controllers
{
    [Authorize(Roles= "Admin")]
    public class UploadFilesController : Controller
    {
        private readonly WebshopContext _context;

        public enum ResultMessage
        {
            Done,
            FailedUploading,
            FailedParsing
        }

        public UploadFilesController(WebshopContext context)
        {
            _context = context;
        }

        public IActionResult index()
        {
            return View();
        }


        #region snippet1

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> index(IFormFile files)
        {
            List<Productwaarde> addedProducts = new List<Productwaarde>();
            List<Attribuutwaarde> addedAttributes = new List<Attribuutwaarde>();
            string filePath;
            try
            {
                // full path to file in temp location
                filePath = Path.GetTempFileName();

                if (files.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await files.CopyToAsync(stream);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception occured whilst uploading a CSV file:");
                Console.WriteLine($"EXCEPTION: {e.Message}");
                Console.WriteLine($"STACKTRACE: {e.StackTrace}");
                ViewBag.resultMsg = ResultMessage.FailedUploading;
                return View();
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.
            try
            {
                string text = System.IO.File.ReadAllText(filePath);
                CsvOptions options = new CsvOptions
                {
                    HeaderMode = HeaderMode.HeaderAbsent
                };
                foreach (var record in CsvReader.ReadFromText(text, options))
                {
                    int id = 0;
                    //productsoortnaam
                    string productss = record[0].ToString();

                    //productsoortidquery
                    var query = from a in _context.Productsoort where a.Naam == productss select a;
                    foreach (var q in query)
                    {
                        id = q.Id;
                    }

                    //productsoortid
                    var productsid = id;


                    var title = record[1].ToString();

                    var price = Convert.ToDouble(record[2]);
                    var description = Convert.ToString(record[3]);
                    var quantity = Int32.Parse(record[4]);
                    var image = Convert.ToString(record[5]);

                    if (string.IsNullOrWhiteSpace(description))
                    {
                        description = "Geen beschrijving beschikbaar!";
                    }

                    Productwaarde productwaarde = new Productwaarde
                    {
                        Title = title,
                        Description = description,
                        Quantity = quantity,
                        Price = price,
                        ProductsoortId = productsid,
                        Image = image,
                        DiscountedPrice = -1
                    };

                    _context.Productwaarde.Add(productwaarde);
                    _context.SaveChanges();
                    addedProducts.Add(productwaarde);

                    var extrattributen = new List<string>();
                    for (int recor = 6; recor < record.ColumnCount; recor++)
                    {
                        extrattributen.Add(record[recor]);
                    }

                    var extraatributenarray = extrattributen.ToArray();

                    var productwid = 0;
                    var productwaardequery = from a in _context.Productwaarde where a.Title == title select a;
                    foreach (var q in productwaardequery)
                    {
                        productwid = q.Id;
                    }

                    var attributenid = new List<int>();
                    var queryatrsid = from a in _context.Attribuutsoort
                        where a.ProductsoortId == productsid
                        select a;
                    foreach (var q in queryatrsid)
                    {
                        attributenid.Add(q.Id);
                    }

                    //atributenid
                    var atributenidarray = attributenid.ToArray();

                    for (int index = 0; index < atributenidarray.Length; index++)
                    {
                        // If CSV didn't contain enough attribute values for all attributes,
                        // we'll use "N/A" as attribute value for the remaining attributes
                        try
                        {
                            Attribuutwaarde attribuutwaarde = new Attribuutwaarde
                            {
                                ProductwaardeId = productwid,
                                AttribuutsoortId = atributenidarray[index],
                                Waarde = extraatributenarray[index]
                            };

                            _context.Attribuutwaarde.Add(attribuutwaarde);
                            _context.SaveChanges();
                            addedAttributes.Add(attribuutwaarde);
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Attribuutwaarde attribuutwaarde = new Attribuutwaarde
                            {
                                ProductwaardeId = productwid,
                                AttribuutsoortId = atributenidarray[index],
                                Waarde = "N/A"
                            };

                            _context.Attribuutwaarde.Add(attribuutwaarde);
                            _context.SaveChanges();
                            addedAttributes.Add(attribuutwaarde);
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("An exception occured whilst reading a CSV file:");
                Console.WriteLine($"EXCEPTION: {e.Message}");
                Console.WriteLine($"STACKTRACE: {e.StackTrace}");
                
                // Rollback the added products/attributes
                if (addedProducts.Any())
                {
                    foreach (var product in addedProducts)
                    {
                        _context.Productwaarde.Remove(product);
                    }

                    _context.SaveChanges();
                }
                
                ViewBag.resultMsg = ResultMessage.FailedParsing;
                return View();
            }

            ViewBag.resultMsg = ResultMessage.Done;
            ViewBag.addedProductCount = addedProducts.Count();
            return View();
        }

        #endregion
    }
}