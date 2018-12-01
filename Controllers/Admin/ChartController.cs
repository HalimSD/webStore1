 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using Microsoft.AspNetCore.Authorization;
 using WebApp1.Models;
 using Microsoft.AspNetCore.Mvc;

 using Models;
 using Remotion.Linq.Clauses;

namespace WebApp1.Controllers
 {
     [Authorize(Roles = "Admin")]
     [Route("/Admin/[controller]/[action]")]
     public class ChartController : Controller
     {
         private readonly WebshopContext context;
        
         public ChartController(WebshopContext context)
         {
             this.context = context;
         }
         
         public IActionResult Statistics()
         {
             return View();
         }

         public JsonResult GetTotalSoldData()
         {
             List<object> objs = new List<object>();
             objs.Add(new[] {"x", "Sold Products"});
             objs.Add(new[] { 0, 45 });
             objs.Add(new[] { 1, 87 });
             objs.Add(new[] { 2, 56 });
             objs.Add(new[] { 3, 67 });
             objs.Add(new[] { 4, 58 });
             objs.Add(new[] { 5, 51 });
             objs.Add(new[] { 6, 49 });
             objs.Add(new[] { 7, 67 });
             return Json(objs);
         }

         public JsonResult GetCategorySold()
         {
             string[] categoryArray = (from ps in context.Productsoort select ps.Naam).ToArray();
             List<BesteldeItem> orders = (from bi in context.BesteldeItem select bi).ToList();
             List<string[]> json = new List<string[]>();
             json.Add(new[] {"Categorieen", "Verkochtte Producten"});

             foreach (string category in categoryArray)
             {
                 int count = 0;
                 foreach (BesteldeItem order in orders)
                 {
                     string categoryName =
                     (
                         from pw in context.Productwaarde
                         from ps in context.Productsoort
                         where pw.Id == order.ProductwaardeId &&
                               pw.ProductsoortId == ps.Id &&
                               ps.Naam == category
                         select ps.Naam
                     ).FirstOrDefault();

                     if (categoryName == null) continue;
                     count += order.Quantity;
                 }
                 
                 json.Add(new[] {category, count.ToString()});
             }
             
             return Json(json);
         }
     }
 }