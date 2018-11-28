using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using WebApp1.products;

namespace klaas.Controllers
{
    public class HomeController : Controller
    {
        protected UserManager<Users> mUserManager;
        protected SignInManager<Users> mSignInManager;
        private readonly WebshopContext _context;
        
        // Defines how many products is displayed foreach page
        private readonly int maxPageSize = 1;
       

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

         public IActionResult Searching(string searchString)
        {
            var products = from m in _context.Productwaarde
                        select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                var query =
                    from productwaarde in _context.Productwaarde
                    join atributen in _context.Attribuutsoort on productwaarde.ProductsoortId equals atributen.ProductsoortId
                    where atributen.Attrbuut.Contains(searchString)
                    select productwaarde;

                var query2 =
                    from attributen in _context.Attribuutwaarde
                    join productwaarde in _context.Productwaarde on attributen.ProductwaardeId equals productwaarde.Id
                    join atribuut in _context.Attribuutsoort on attributen.AttribuutsoortId equals atribuut.Id
                    where attributen.Waarde.Contains(searchString)
                    select productwaarde;

                products = products.Where(s => s.Title.Contains(searchString)).Union(query).Union(query2);
                return View("Search",products);
            }

            return View("Search",products);
        }

        public IActionResult Search()
        {
            return View();
        }

       

      
        public IActionResult Mainpage(string productsrt, int? id)
        {

            var productsoorten = from m in _context.Productsoort select m;


             if (productsrt == null)
            {
                var productwaardenq =  from m in _context.Productwaarde select m;
                var main = new WebApp1.Mainpage.Mainpage();
                    main.productwaardes = productwaardenq;
                    main.currentCategoryName = "Alle Producten";
                    main.productsoorten = productsoorten;
                    main.pagesize = maxPageSize;
                    main.pageindex = (id ?? 1);
                return View(main);
            }

            else if (productsrt == "Alle Producten"){
                var productwaardenq =  from m in _context.Productwaarde select m;
                var main = new WebApp1.Mainpage.Mainpage();
                    main.productwaardes = productwaardenq;
                    main.currentCategoryName = "Alle Producten";
                    main.productsoorten = productsoorten;
                    main.pagesize = maxPageSize;
                    main.pageindex = (id ?? 1);
                return View(main);
            }

            else{
                var query =
                        from productsoort in _context.Productsoort
                        join productwaarde in _context.Productwaarde on productsoort.Id equals productwaarde.ProductsoortId
                        where productsoort.Naam == productsrt 
                        select productwaarde;

                var main = new WebApp1.Mainpage.Mainpage();
                            main.productwaardes = query;
                            main.currentCategoryName = productsrt;
                            main.productsoorten = productsoorten;
                            main.pagesize = maxPageSize;
                            main.pageindex = (id ?? 1);
                return View(main);
            }
        }


        public IActionResult Contact()
        {
            ViewData["Message"] = "";

            return View();
        }
        public IActionResult Signin()
        {
            ViewData["Message"] = "LogIn.";

            return RedirectToAction("Login", "Account");
        }
        public IActionResult signup()
        {
            ViewData["Message"] = "Sign Up.";

            return RedirectToAction("Register", "Account");
        }

         public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // [Route ("signup")]
        // public async Task<IActionResult> CreatUserAsync(){
        //     var result = await mUserManager.CreateAsync(new Users{
        //         UserName = "halim",
        //         Email = "halim@gmail.com"
        //     }, "1.Password");
        //     if (result.Succeeded)
        //         return Content("user was created", "text/html");
            
        //     return Content ("user creation faild", "text/html");
        // }

        [Authorize]
        [Route("profile")]
        public IActionResult userProfile(){
            return Content($"Welcome {HttpContext.User.Identity.Name} this is your profile.", "text/html");
        }

        // [Route("login")]
        // public async Task <IActionResult> login(string returnUrl){
        //    await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
        //    var result = await mSignInManager.PasswordSignInAsync("halim", "1.Password", true, false);
        //    if (result.Succeeded){
        //        if (string.IsNullOrEmpty(returnUrl))
        //             return RedirectToAction(nameof(Index));
        //     return Redirect (returnUrl);
        //    }
        //    return Content("Faild to login", "text/html");
        // }

        
        [HttpGet]
        [Route("logout")]
        public async Task <IActionResult> logout(){
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return Content ("Logged out.", "text/html");
        }
    }
}