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
     
        public IActionResult Mainpage(List<WebApp1.Mainpage.Mainpage.Productsoortfilter> productsoortfilters, int? id)
        {
           

            var productsoortenfilter = from m in _context.Productsoort select new WebApp1.Mainpage.Mainpage.Productsoortfilter(){Productsoorts = m, selected = false };
            var productsoortfilterslijst = productsoortenfilter.ToList();
            var productsoorten = from m in _context.Productsoort select m;
            
            // var query1 =
            //             (from productsoort in _context.Productsoort
            //             join atributen in _context.Attribuutsoort on productsoort.Id equals atributen.ProductsoortId 
            //             group atributen by productsoort into g
            //             select new Prodctding(){Attribuutsoorts = g.ToList(), Productsoorts = g.Key}).ToList();

             if (productsoortfilters.Count == 0)
            {
                var productwaardenq =  from m in _context.Productwaarde orderby m.Title select m;
                var main = new WebApp1.Mainpage.Mainpage();
                    main.productwaardes = productwaardenq;
                    main.currentCategoryName = "Alle Producten";
                    main.productsoortfilters = productsoortfilterslijst;
                    main.productsoorten = productsoorten;
                    main.pagesize = maxPageSize;
                    main.pageindex = (id ?? 1);
                return View(main);
            }
            else{
                 var myList = new List<Productsoort>();
                for (var i = 0; i<productsoortfilters.Count(); i++ ){
                    if(productsoortfilters[i].selected == true){
                        myList.Add(productsoortfilters[i].Productsoorts);
                    }
                }

                if (myList.Count == 0){
                    var productwaardenq =  from m in _context.Productwaarde select m;
                    var main = new WebApp1.Mainpage.Mainpage();
                    main.productwaardes = productwaardenq;
                    main.currentCategoryName = "Alle Producten";
                    main.productsoortfilters = productsoortfilterslijst;
                    main.productsoorten = productsoorten;
                    main.pagesize = maxPageSize;
                    main.pageindex = (id ?? 1);
                    return View(main);
                }
                else{
                    var productwaardenlijst = new List<Productwaarde>();
                    for (var i = 0; i<myList.Count(); i++ ){
                    var query =
                            from productsoort in _context.Productsoort
                            join productwaarde in _context.Productwaarde on productsoort.Id equals productwaarde.ProductsoortId
                            where productsoort.Naam == myList[i].Naam
                            select productwaarde;
                        productwaardenlijst = productwaardenlijst.Union(query).ToList();
                    }

                    var main = new WebApp1.Mainpage.Mainpage();
                                main.productwaardes = productwaardenlijst;
                                main.currentCategoryName = "filteredresult";
                                main.productsoortfilters = productsoortfilterslijst;
                                main.pagesize = maxPageSize;
                                main.pageindex = (id ?? 1);
                    return View(main);
                }
            }
        }
    }
}