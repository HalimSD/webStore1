
using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;

namespace WebApp1.Areas.Identity.Pages.Account
{
    public class Account : Controller
    {
         private readonly WebshopContext context;
        private readonly int maxPageSize = 20;
        
        public Account(WebshopContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();

        }
    }
}