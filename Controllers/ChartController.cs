 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using Microsoft.AspNetCore.Authorization;
 using WebApp1.Models;
 using Microsoft.AspNetCore.Mvc;

 using Models;

 namespace WebApp1.Controllers
 {
     [Authorize(Roles = "Admin")]
     public class ChartController : Controller
     {
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
             List<CategorySoldColsModel> column = new List<CategorySoldColsModel>
             {
                 new CategorySoldColsModel
                 {
                     id = "taxType",
                     label = "Tax Type",
                     type = "string"
                 },
                 new CategorySoldColsModel
                 {
                     id = "percent",
                     label = "Tax Percentage",
                     type = "number"
                 }
             };
             List<CategorySoldRowsModel> row = new List<CategorySoldRowsModel>
             {
                 new CategorySoldRowsModel
                 {
                     c = new List<object>
                     {
                         new CategorySoldColName
                         {
                             v = "Speedboten"
                         },
                         new CategorySoldValName
                         {
                             v = 30
                         }
                     }
                 },
                 new CategorySoldRowsModel
                 {
                     c = new List<object>
                     {
                         new CategorySoldColName
                         {
                             v = "Zeilboten"
                         },
                         new CategorySoldValName
                         {
                             v = 50
                         }
                     }
                 },
                 new CategorySoldRowsModel
                 {
                     c = new List<object>
                     {
                         new CategorySoldColName
                         {
                             v = "Boot Onderdelen"
                         },
                         new CategorySoldValName
                         {
                             v = 20
                         }
                     }
                 }
             };

             CategorySoldModel json = new CategorySoldModel {
                 cols = column,
                 rows = row
             };
             return Json(json);
         }
     }
 }