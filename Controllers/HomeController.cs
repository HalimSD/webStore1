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
     
         public IActionResult Mainpage(List<WebApp1.Mainpage.Mainpage.Productsoortfilter> productsoortfilters, List<WebApp1.Mainpage.Mainpage.Prodctding> prodctding, double? minprice , double? maxprice, int? id)
        {
           

            var productsoortenfilter = from m in _context.Productsoort select new WebApp1.Mainpage.Mainpage.Productsoortfilter(){Productsoorts = m, selected = false };
            var productsoortfilterslijst = productsoortenfilter.ToList();
            var productsoorten = from m in _context.Productsoort select m;
            
            var quer = new List<WebApp1.Mainpage.Mainpage.Prodctding>{}.ToList();

            

           
            if(prodctding.Count != 0){
                var productwaardenlijst1 = new List<Productwaarde>();
                // if (minprice!= null && maxprice!= null){
                //         var produtwaarde = from productwaarde in _context.Productwaarde 
                //                         where productwaarde.Price> minprice && 
                //                         productwaarde.Price<= maxprice 
                //                         select productwaarde;
                //         productwaardenlijst1 = productwaardenlijst1.Union(produtwaarde).ToList();
                // }
                    for (var i = 0; i<prodctding.Count(); i++ ){
                     if(prodctding[i].Attribuutsoortst!=null){
                        for(var k = 0; k < prodctding[i].Attribuutsoortst.Count; k++){

                            var query =
                                from attributen in _context.Attribuutwaarde
                                join productwaarde in _context.Productwaarde on attributen.ProductwaardeId equals productwaarde.Id
                                join atribuut in _context.Attribuutsoort on attributen.AttribuutsoortId equals atribuut.Id
                                join productsoort in _context.Productsoort on productwaarde.ProductsoortId equals productsoort.Id
                                where attributen.Waarde.Contains(prodctding[i].Attribuutsoortst[k].value) && productsoort.Naam == prodctding[i].Productsoorts.Naam &&
                                productwaarde.Price> minprice && 
                                        productwaarde.Price<= maxprice 
                                select productwaarde;

                                productwaardenlijst1 = productwaardenlijst1.Union(query).ToList();
                        }
                     }

                      if(prodctding[i].Attribuutsoortsn!= null){
                        for(var k = 0; k < prodctding[i].Attribuutsoortsn.Count; k++){

                            var query1 =
                                from attribuutwaarde in _context.Attribuutwaarde
                                join productwaarde in _context.Productwaarde on attribuutwaarde.ProductwaardeId equals productwaarde.Id
                                join atribuutsoorten in _context.Attribuutsoort on attribuutwaarde.AttribuutsoortId equals atribuutsoorten.Id
                                join productsoort in _context.Productsoort on productwaarde.ProductsoortId equals productsoort.Id
                                where atribuutsoorten.Type == "number" && productsoort.Naam == prodctding[i].Productsoorts.Naam && Int32.Parse(attribuutwaarde.Waarde)> prodctding[i].Attribuutsoortsn[k].min && 
                                Int32.Parse(attribuutwaarde.Waarde)<= prodctding[i].Attribuutsoortsn[k].max &&
                                  productwaarde.Price> minprice && 
                                        productwaarde.Price<= maxprice 
                                select productwaarde;

                                
                            
                            // var query2 = query1.Where(x => Convert.ToInt32("100")> prodctding[i].Attribuutsoortsn[k].min && 
                            //      Convert.ToInt32("100")<= prodctding[i].Attribuutsoortsn[k].max
                            //      ).Select(x => x.productwaarde);

                            //  var query2 = query1.
                            //  Select(x => x.productwaarde);
                               
                                
                                

                                productwaardenlijst1 = productwaardenlijst1.Union(query1).ToList();
                        }
                     }
                    }

                    var main = new WebApp1.Mainpage.Mainpage();
                                main.productwaardes = productwaardenlijst1;
                                main.currentCategoryName = "filteredresult";
                                main.prodctding = prodctding;
                                main.productsoortfilters = productsoortfilterslijst;
                                main.pagesize = maxPageSize;
                                main.pageindex = (id ?? 1);
                    return View(main);
            }

            if (minprice!= null && maxprice!= null){
                var produtwaarde = from productwaarde in _context.Productwaarde 
                                where productwaarde.Price> minprice && 
                                productwaarde.Price<= maxprice 
                                select productwaarde;
                var main = new WebApp1.Mainpage.Mainpage();
                    main.productwaardes = produtwaarde;
                    main.prodctding = quer;
                    main.currentCategoryName = "Alle Producten";
                    main.productsoortfilters = productsoortfilterslijst;
                    main.productsoorten = productsoorten;
                    main.pagesize = maxPageSize;
                    main.pageindex = (id ?? 1);
                return View(main);
            }

             

             else if (productsoortfilters.Count == 0) 
            {
                var productwaardenq =  from m in _context.Productwaarde orderby m.Title select m;
                var main = new WebApp1.Mainpage.Mainpage();
                    main.productwaardes = productwaardenq;
                    main.prodctding = quer;
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
                    main.prodctding = quer;
                    main.pagesize = maxPageSize;
                    main.pageindex = (id ?? 1);
                    return View(main);
                }
                else{
                    var productwithatlijst = new List<WebApp1.Mainpage.Mainpage.Prodctding>();
                    foreach(var item in myList){
                        var productding1 = new WebApp1.Mainpage.Mainpage.Prodctding();
                        productding1.Productsoorts = item;
                       var atribuutsoortn = (from atribuutsoort in _context.Attribuutsoort
                                        join productsoort in _context.Productsoort on atribuutsoort.ProductsoortId equals productsoort.Id
                                         where productsoort.Naam == item.Naam && atribuutsoort.Type == "number"
                                         select new WebApp1.Mainpage.Mainpage.Atribuutsoortnumber(){atribuutsoortn = atribuutsoort, min = 0, max = 10}); 
                        productding1.Attribuutsoortsn= atribuutsoortn.ToList();
                        var atribuutsoortt = (from atribuutsoort in _context.Attribuutsoort
                                        join productsoort in _context.Productsoort on atribuutsoort.ProductsoortId equals productsoort.Id
                                         where productsoort.Naam == item.Naam && atribuutsoort.Type == "string"
                                         select new WebApp1.Mainpage.Mainpage.Atribuutsoorttekst(){atribuutsoortt = atribuutsoort,value = "henk"}); 
                        productding1.Attribuutsoortst= atribuutsoortt.ToList();
                        productwithatlijst.Add(productding1);
                         
                    }

                    //  var productwithatlijst = new List<WebApp1.Mainpage.Mainpage.Prodctding>();
                    //  for (var i = 0; i<myList.Count(); i++ ){

                    //     var subquery1 = (from atribuutsoorten in _context.Attribuutsoort
                    //                     where atribuutsoorten.Type == "number"
                    //                     select new WebApp1.Mainpage.Mainpage.Atribuutsoortnumber(){atribuutsoortn = atribuutsoorten, min = 0, max = 10});
                    //     var query1 =
                    //                 (from productsoort in _context.Productsoort
                    //                 join atributen in subquery1 on productsoort.Id equals atributen.atribuutsoortn.ProductsoortId
                    //                 where productsoort.Naam == myList[i].Naam 
                    //                 group atributen by productsoort into g
                    //                 select new WebApp1.Mainpage.Mainpage.Prodctding(){Productsoorts = g.Key, Attribuutsoortsn = g.ToList()}).ToList();
                    //     productwithatlijst = productwithatlijst.Union(query1).ToList();

                    //     var subquery2 = (from atribuutsoorten in _context.Attribuutsoort
                    //                     where atribuutsoorten.Type == "string"
                    //                     select new WebApp1.Mainpage.Mainpage.Atribuutsoorttekst(){atribuutsoortt = atribuutsoorten, value = "hoi"});

                    //     var query2 =
                    //                 (from productsoort in _context.Productsoort
                    //                 join atributen in subquery2 on productsoort.Id equals atributen.atribuutsoortt.ProductsoortId
                    //                 where productsoort.Naam == myList[i].Naam 
                    //                 group atributen by productsoort into g
                    //                 select new WebApp1.Mainpage.Mainpage.Prodctding(){Productsoorts = g.Key, Attribuutsoortst = g.ToList()}).ToList();
                    //     productwithatlijst = productwithatlijst.Union(query2).ToList();
                       
                    // }

                    // //list with products
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
                                main.prodctding = productwithatlijst;
                                main.productsoortfilters = productsoortfilterslijst;
                                main.pagesize = maxPageSize;
                                main.pageindex = (id ?? 1);
                    return View(main);

                }
            }
        }
    }
}