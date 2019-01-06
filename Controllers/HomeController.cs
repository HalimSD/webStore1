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
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using Org.BouncyCastle.Crypto.Signers;

namespace klaas.Controllers
{
    public class HomeController : Controller
    {
        protected UserManager<Users> mUserManager;
        protected SignInManager<Users> mSignInManager;
        private readonly WebshopContext _context;
       

         public HomeController(UserManager<Users> userManager, SignInManager<Users> signInManager, WebshopContext context)
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
            
            if (SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                SessionExtensions.Set(HttpContext.Session, "cart", cart);
            }
            
            var root1 = (from r in _context.ParentChild where!(from c in _context.ParentChild select c.ChildId).Contains(r.ParentId) select r.ParentId).FirstOrDefault();
            // var parent = from pc in _context.ParentChild group pc by pc.ParentId into g select g;
            // var ChildId = from pc in _context.ParentChild select pc.ChildId;
            // var Child = ChildId.ToArray();
            // var ParentId = from pc in _context.ParentChild select pc.ParentId;
            // var Parent = ParentId.ToArray();
            // var root = 0;
            // foreach(var item in Parent){
            //     if (!Child.Contains(item)){
            //         root = item; 
            //     }
            // }
             var main = new Datastructure();
            var result =  from m in _context.Productwaarde select m;
            if (root1 != 0){main.kaas = CreateSubTree(root1);}
            
            main.productwaardes = result;
            
 

              
            return View(main);
        }
         public Node CreateSubTree(int id)
        {
            var parent = (from p in _context.Productsoort where p.Id == id select p).FirstOrDefault();
            var subtree = new Node(parent.Naam,parent.Image,parent.Id);
            var children = from c in _context.ParentChild where c.ParentId ==id select c;
            foreach (var c in children){
              subtree.Add(CreateSubTree(c.ChildId));
                
            } 
            
            return subtree;
        }
       

         public IActionResult Index2()
        {
            var kaas = CreateSubTree(1);
            
            var main = new Datastructure(){kaas = kaas};
            return View(main);
        }
         
         public class Node
        {
            public string name {get; set;}

            public string image {get;set;}
            public int id{get;set;}
            public List<Node> children {get; set;}

            public Node(string n, string i, int d)
            {
                name = n;
                image = i;
                id = d;
                children = new List<Node>(); 
            }

            public Node(string n, string i, int d, List<Node> l)
            {
                name = n;
                image = i;
                id = d;
                children = l; 
            }

            public void Add(string n, string i, int d)
            {
                children.Add(new Node(n,i,d));
            }

            public void Add(Node n)
            {
                children.Add(n);
            }

        }



        public IActionResult Mainpage()
        {
            return RedirectToAction("Index", "Category");
        }

        /// <summary>
        /// Get the item count in favorites for the current User
        /// </summary>
        /// <returns>Favorites item count. Or returns -1 if not signed in</returns>
        public int GetFavoriteCount()
        {
            if (!User.Identity.IsAuthenticated) return -1;
            string userId = mUserManager.GetUserId(User);
            return (from f in _context.Favorites where f.UserId == userId select f).Count();
        }

        
        /// <summary>
        /// Return the item count in the cart
        /// </summary>
        /// <returns>Cart item count</returns>
        public int GetCartCount()
        {
            List<Item> cart = SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart");
            if (cart == null) return 0;

            return cart.Count();
        }
    }
}