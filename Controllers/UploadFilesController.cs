using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;
using WebApp1.products;
using System;

namespace Controllers
{
    public class UploadFilesController : Controller
    {
         private readonly WebshopContext _context;

        public UploadFilesController  (WebshopContext context) {
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
            string content = files.ContentType;

            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            
                if (files.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await files.CopyToAsync(stream);
                    }
                }
            
            // process uploaded files
            // Don't rely on or trust the FileName property without validation.
             string output = "done";
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
                using (StreamReader reader = new StreamReader(fileStream))
                {
                   
                        string line;
                        // Read and display lines from the file until the end of 
                        // the file is reached.
                        while ((line = reader.ReadLine()) != null) 
                        {
                            string[] total = line.Split(';');
                            int id = 0;
                
                            foreach(string i in total){
                                var record = i.Split(new string[] { "," }, StringSplitOptions.None);
                              
                                //productsoortnaam
                                string productss = record[0].ToString();

                                //productsoortidquery
                               var query = from a in _context.Productsoort where a.Naam == productss select a;
                                foreach (var q in query){
                                    id = q.Id;
                                }
                                
                                //productsoortid
                                var productsid = id;

                                
                                var title = record[1].ToString();

                                var price = Convert.ToDouble(record[2]);

                                Productwaarde productwaarde = new Productwaarde{
                                Title = title,
                                Price = price,
                                ProductsoortId = productsid,
                                Image = "default.png"
                            };

                            _context.Productwaarde.Add(productwaarde);
                            _context.SaveChanges();

                             var extrattributen = new List<string>();
                             for (int recor = 3; recor < record.Length; recor++)
                                { 
                                    extrattributen.Add(record[recor]);
                                }
                             var extraatributenarray = extrattributen.ToArray();
                            
                            var productwid = 0;
                            var productwaardequery = from a in _context.Productwaarde where a.Title == title select a;
                                foreach (var q in productwaardequery){
                                    productwid = q.Id;
                                }

                                var attributenid = new List<int>();
                                var queryatrsid = from a in _context.Attribuutsoort where a.ProductsoortId == productsid select a;
                                foreach (var q in queryatrsid){
                                attributenid.Add(q.Id);
                                }
                                
                                //atributenid
                                var atributenidarray = attributenid.ToArray();

                             for (int index = 0; index < atributenidarray.Length; index++){
                              Attribuutwaarde attribuutwaarde = new Attribuutwaarde{
                                  ProductwaardeId = productwid,
                                  AttribuutsoortId = atributenidarray[index],
                                  Waarde = extraatributenarray[index]
                              };
                              _context.Attribuutwaarde.Add(attribuutwaarde);
                            _context.SaveChanges();
                            }
                            }
                            
                            
                        }
                    }
                
            ViewData["Message"] = output;
            return View();
        }
        #endregion
    }
}