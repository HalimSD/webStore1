 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using Microsoft.AspNetCore.Authorization;
 using WebApp1.Models;
 using Microsoft.AspNetCore.Mvc;
 using Remotion.Linq.Clauses;
 using WebApp1.Models.Database;

 namespace WebApp1.Controllers
 {
     [Authorize(Roles = "Admin")]
     [Route("/Admin/[controller]/")]
     public class StatisticsController : Controller
     {
         private readonly WebshopContext context;
        
         public StatisticsController(WebshopContext context)
         {
             this.context = context;
         }
         
         public IActionResult Index()
         {
             List<string[]> tableRows = new List<string[]>();
             
             // Add total revenue statistic
             double revenue = (from bi in context.OrderDetail select bi.Price).Sum();
             tableRows.Add(new[] {"Totale Omzet", "€ " + revenue.ToString()});
             
             // Add Total sold statistic
             int soldCount = (from bi in context.OrderDetail select bi.Quantity).Sum();
             tableRows.Add(new[] {"Totaal verkochtte producten", soldCount.ToString()});
             
             // Add total products statistic
             int productCount = (from pw in context.Product select pw).Count();
             tableRows.Add(new[] {"Totaal Aantal Producten", productCount.ToString()});
             
             // Add products in stock statistic
             int inStockCount = (from pw in context.Product where pw.Quantity > 0 select pw).Count();
             tableRows.Add(new[] {"Aantal producten In Voorraad", inStockCount.ToString()});

             ViewBag.chartTableRows = tableRows;
             return View();
         }
         
         [Route("GetTotalSoldData")]
         public JsonResult GetTotalSoldData()
         {
             Order[] orders = (from b in context.Order select b).ToArray();
             List<string[]> json = new List<string[]>();
             json.Add(new[] {"X", "Verkochtte Producten"});
             
             // Each value in array represents sold count for specific day
             // index 0: 0 days ago
             // index 1: 1 days ago
             // etc...
             int[] soldCount = new int[7] {0,0,0,0,0,0,0};
             
             foreach (Order order in orders)
             {
                 // Figure out which day it should be part off
                 // -1 Means it happened more than a week ago
                 int index = -1;
                 if (order.Date.ToShortDateString() == DateTime.Today.ToShortDateString()) { index = 0; }
                 if (order.Date.ToShortDateString() == DateTime.Today.AddDays(-1).ToShortDateString()) { index = 1; }
                 if (order.Date.ToShortDateString() == DateTime.Today.AddDays(-2).ToShortDateString()) { index = 2; }
                 if (order.Date.ToShortDateString() == DateTime.Today.AddDays(-3).ToShortDateString()) { index = 3; }
                 if (order.Date.ToShortDateString() == DateTime.Today.AddDays(-4).ToShortDateString()) { index = 4; }
                 if (order.Date.ToShortDateString() == DateTime.Today.AddDays(-5).ToShortDateString()) { index = 5; }
                 if (order.Date.ToShortDateString() == DateTime.Today.AddDays(-6).ToShortDateString()) { index = 6; }

                 // If it doesn't fall under this week, purchase will not be included
                 // Skip this iteration of the foreach loop
                 if (index == -1) continue;
                 
                 // Amount of products in this specific order
                 int productCount =
                 (
                     from bi in context.OrderDetail
                     where bi.OrderId == order.Id
                     select bi.Quantity
                 ).Sum();

                 soldCount[index] += productCount;
             }

             for (int i = soldCount.Length - 1; i >= 0; i--)
             {
                 json.Add(new[] {DateTime.Today.AddDays(i*-1).ToShortDateString(), soldCount[i].ToString()});
             }
             
          return Json(json);
         }

         [Route("GetCategorySold")]
         public JsonResult GetCategorySold()
         {
             string[] categoryArray = (from ps in context.Category select ps.Naam).ToArray();
             List<OrderDetail> orders = (from bi in context.OrderDetail select bi).ToList();
             List<string[]> json = new List<string[]>();
             json.Add(new[] {"Categorieen", "Verkochtte Producten"});

             foreach (string category in categoryArray)
             {
                 int count = 0;
                 foreach (OrderDetail order in orders)
                 {
                     string categoryName =
                     (
                         from pw in context.Product
                         from ps in context.Category
                         where pw.Id == order.ProductId &&
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