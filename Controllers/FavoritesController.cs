using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using WebApp1.Models;
using WebApp1.Models.Database;

namespace WebApp1.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly WebshopContext context;
        private readonly UserManager<Users> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<Users> signInManager;
        
        public FavoritesController (WebshopContext context, UserManager<Users> userManager, RoleManager<IdentityRole> roleManager, SignInManager<Users> signInManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }
        
        [Authorize]
        public IActionResult Index()
        {
            string userId = userManager.GetUserId(User);
            List<FavoritesViewModel> products =
            (
                from f in context.Favorite
                from pw in context.Product
                where f.UserId == userId && f.ProductId == pw.Id
                select new FavoritesViewModel
                {
                    ProductId = f.ProductId,
                    ProductName = pw.Title,
                    Price = "€" + pw.Price.ToString(),
                    Date = f.Date
                }
            ).ToList();
            ViewBag.favProducts = products;
            return View();
        }
                
        [Authorize]
        public IActionResult AddProduct(int id)
        {
            Favorite model = new Favorite
            {
                ProductId = id,
                UserId = userManager.GetUserId(User),
                Date = DateTime.Now.ToShortDateString()
            };

            int count = 
                (from f in context.Favorite
                where f.ProductId == model.ProductId && f.UserId == model.UserId
                select f).Count();
            
            // If product is already within user's favorites then skip it
            if (count == 0)
            {
                context.Favorite.Add(model);
                context.SaveChanges();
            }
            
            // Redirect back to product page
            int productId = id;
            return RedirectToAction("Index", "ViewProduct", new { id = productId });
        }
        
        [Authorize]
        public IActionResult RemoveProduct(int id, string returnUrl)
        {
            var res =
                from f in context.Favorite
                where f.ProductId == id && f.UserId == userManager.GetUserId(User)
                select f;

            Favorite model = res.FirstOrDefault();
            
            // If product is already within user's favorites then skip it
            if (res.Any() && model != null)
            {
                context.Favorite.Remove(model);
                context.SaveChanges();
            }
            
            // Redirect back to product page
            int productId = id;
            return Redirect(returnUrl);
        }
        
    }
}