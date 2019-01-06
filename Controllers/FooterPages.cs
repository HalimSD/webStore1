using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class FooterPages : Controller
    {
         public IActionResult Index()
        {
            return View("Betalen");
        }
        public IActionResult Betalen()
        {
            return View();
        }
    }
}