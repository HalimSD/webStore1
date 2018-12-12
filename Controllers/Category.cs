using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class Category : Controller
    {
        private readonly int maxPageSize = 9;
        private readonly WebshopContext context;
        private PaginationHelper<Productwaarde> paginationProductwaarde;
        
        public Category(WebshopContext context)
        {
            this.context = context;
            paginationProductwaarde = new PaginationHelper<Productwaarde>(maxPageSize, context.Productwaarde);
        }
        
        // GET
        public IActionResult Index(int? categoryId, int? pageNumber)
        {
            if (pageNumber == null)
            {
                pageNumber = 1;
            }
            
            var modelHelper = new CategoryViewModelHelper(maxPageSize, context);
            return View(modelHelper.CreateViewModel(categoryId, (int) pageNumber));
        }
    }
}