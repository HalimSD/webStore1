using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;

namespace WebApp1.Controllers.Admin
{
    [Route("/admin/[controller]/")]
    public class ProductListController : Controller
    {
        private readonly WebshopContext context;
        
        public ProductListController(WebshopContext context)
        {
            this.context = context;
        }
        
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("GetData")]
        public JsonResult GetData()
        {
            // Use the helper class associated with that model to get all product data
            List<ProductListViewModel> json = new ProductListViewModelHelper().GetData(context);
            
            // Encode to JSON and return it
            return new JsonResult(json);
        }

        [Route("GetDataFiltered")]
        public JsonResult GetDataFiltered(string id="", string name="", string price="", string stock="", string category="")
        {
            // Some error checking as JS may give null values!
            if (id == null) { id = ""; }
            if (name == null) { name = ""; }
            if (price == null) { price = ""; }
            if (stock == null) { stock = ""; }
            if (category == null) { category = ""; }
            
            // Use the helper class associated with that model to get all product data
            List<ProductListViewModel> data = new ProductListViewModelHelper().GetData(context);   
            
            // This list will contain the filtered items
            List<ProductListViewModel> filtered = new List<ProductListViewModel>();
            
            // We will loop through the data and filter everything out
            // For each element, we check if all applicable fields pass the filter
            // If they all pass, then they will be added to the filtered list
            foreach (ProductListViewModel item in data)
            {
                bool containsId = item.Id.ToString().Contains(id);
                bool containsName = item.Name.ToUpper().Contains(name.ToUpper());
                bool containsPrice = item.Price.ToString().Contains(price);
                bool containsStock = item.Quantity.ToString().Contains(stock);
                bool containsCategory = item.Category.ToUpper().Contains(category.ToUpper());

                if (containsId && containsName && containsPrice && containsStock && containsCategory)
                {
                    filtered.Add(item);
                }
            }
            
            // Encode to JSON and return it
            return new JsonResult(filtered);
        }
    }

}