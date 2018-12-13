using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Search;
using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Org.BouncyCastle.Crypto.Signers;

namespace klaas.Controllers
{
    public class HomeController : Controller
    {
        protected UserManager<Users> mUserManager;
        protected SignInManager<Users> mSignInManager;
        private readonly WebshopContext _context;
        
        // Defines how many products is displayed foreach page
        private readonly int maxPageSize = 9;
       

         public HomeController(
            
            UserManager<Users> userManager,
            SignInManager<Users> signInManager, WebshopContext context)
            {
            
            mUserManager = userManager;
            mSignInManager = signInManager;
             _context = context;
            }
        public IActionResult Index()
        {            
            var myList = new List<string>();
            var productsoorten = from m in _context.Productsoort select new {m.Naam};

            foreach (var product in productsoorten){
                myList.Add(product.ToString());
                Console.WriteLine(product.Naam);
            }
            var myArray = myList.ToArray();
            ViewData["productsoorten"] =  myArray;
            var result =  from m in _context.Productwaarde select m;
            if (SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                SessionExtensions.Set(HttpContext.Session, "cart", cart);
            }
            return View(result);
        }

        public IActionResult Mainpage()
        {
            return RedirectToAction("Index", "Category");
        }
     
    }
}