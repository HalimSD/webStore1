using System.Linq;
using System.Runtime.CompilerServices;
using WebApp1.Models;
using WebApp1.products;
using Microsoft.AspNetCore.Mvc;
using NuGet.Frameworks;

namespace WebApp1.Controllers
{
    [Route("/admin/[controller]/")]
    public class EditProductController : Controller
    {
        private readonly WebshopContext context;

        public EditProductController(WebshopContext context)
        {
            this.context = context;
        }
        
        [Route("")]
        [Route("Index")]
        public IActionResult Index(int id)
        {
            Productwaarde product = (from pw in context.Productwaarde where pw.Id == id select pw).FirstOrDefault();
            ViewBag.EditProduct = product;
            return View();
        }
    }
}