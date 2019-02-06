using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WebApp1.Models;
using Microsoft.AspNetCore.Mvc;
using Remotion.Linq.Clauses;
using WebApp1.Models.Database;
using WebApp1.Models.Helper;
using WebApp1.Models.Helper.Statistics;
using WebApp1.Models.ViewModels;

namespace WebApp1.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("/Admin/[controller]/")]
    public class StatisticsController : Controller
    {
        private readonly WebshopContext context;
        private readonly StatisticsHelper statistics;

        public StatisticsController(WebshopContext context)
        {
            this.context = context;
            statistics = new StatisticsHelper(context);
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

        [Route("GetTotalSoldData/{range=Week}")]
        public JsonResult GetTotalSoldData(StatisticsHelper.Range range = StatisticsHelper.Range.Week)
        {
            StatisticsViewModel<string[]> model = new StatisticsViewModel<string[]>
            {
                Data = statistics.GetTotalSold(range)
            };
            return Json(model);
        }

        [Route("GetCategorySold/{range=Week}")]
        public JsonResult GetCategorySold(StatisticsHelper.Range range = StatisticsHelper.Range.Week)
        {
            StatisticsViewModel<string[]> model = new StatisticsViewModel<string[]>
            {
                Data = statistics.GetCategorySold(range)
            };
            return Json(model);
        }
        
        [Route("GetDataFiltered")]
        public JsonResult GetDataFiltered(string id="", string name="", string category="", string stock="", int pageIndex=1)
        {
            // Create a PaginationHelper instance. It will be used to generate a page
            PaginationHelper<Product> pagination = new PaginationHelper<Product>(5,context.Product);
            
            // Some error checking as JS may give null values!
            if (id == null) { id = ""; }
            if (name == null) { name = ""; }
            if (category == null) { category = ""; }

            if (string.IsNullOrWhiteSpace(stock)) stock = "10";

            // Since the pagination helper doesn't have built-in filtering,
            // we'll have to prepare a custom filtered query and pass it to the helper
            // First we do the string based filtering
            IQueryable<Product> query =
                from pw in context.Product
                from ps in context.Category
                where pw.CategoryId == ps.Id &&
                      pw.Title.ToUpper().Contains(name.ToUpper()) &&
                      ps.Naam.ToUpper().Contains(category.ToUpper())
                select pw;
            
            // Do the number filters
            if (id != "")
            {
                query = from pw in query where pw.Id == int.Parse(id) select pw;
            }
            query = from pw in query where pw.Quantity <= int.Parse(stock) select pw;
            
            // Generate pages from the custom query
            PaginationViewModel<Product> productPage = pagination.GetPageIQueryable(pageIndex, query);
            
            // Since the default Productwaarde doesn't contain all of the needed info
            // We will create a new model that we will return
            PaginationViewModel<ProductListViewModel> json =
                new ProductListViewModelHelper().ConvertToViewModel(context, productPage);
            
            // Encode to JSON and return it
            return new JsonResult(json);
        }
    }
}