﻿using System;
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
            var result =  from m in _context.Productwaarde select m;
            var kaas = CreateSubTree(root1);
            var main = new Datastructure();
            main.kaas=kaas;
            main.productwaardes = result;
            


              
            return View(main);
        }
         public Node CreateSubTree(int id)
        {
            var parent = (from p in _context.Productsoort where p.Id == id select p.Naam).FirstOrDefault();
            var subtree = new Node(parent);
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
            public List<Node> children {get; set;}

            public Node(string n)
            {
                name = n;
                children = new List<Node>(); 
            }

            public Node(string n, List<Node> l)
            {
                name = n;
                children = l; 
            }

            public void Add(string n)
            {
                children.Add(new Node(n));
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
     
    }
}