using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebApp1.products;
using Microsoft.EntityFrameworkCore;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.AspNetCore.Identity;
using MailKit.Net.Imap;

namespace LearnASPNETCoreMVCWithRealApps.Controllers
{
    [Route("cart")]

    public class CartController : Controller
    {
        private readonly WebshopContext _context;
        private UserManager<Users> _userManager;

        public const string SessionKeyName = "_Name";
        public string SessionInfo_Name { get; private set; }

        public CartController(WebshopContext context, UserManager<Users> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        [Route("buy/{id}")]
        public IActionResult Buy(int id)
        {
            Productwaarde productModel = new Productwaarde();
            if (SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = _context.Productwaarde.Find(id), Quantity = 1 });
                SessionExtensions.Set(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = _context.Productwaarde.Find(id), Quantity = 1 });
                }
                SessionExtensions.Set(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }
        [Route("index")]
        public IActionResult Index()
        {
            var cart = SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
            return View();
        }
        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<Item> cart = SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionExtensions.Set(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int isExist(int id)
        {
            List<Item> cart = SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }


        public IActionResult checkOut()
        {
            var cart = SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);

            return View("checkOut");

        }

        [Route("pay")]
        public IActionResult pay()
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Halim", "testprojecthr@gmail.com"));
            message.To.Add(new MailboxAddress(_userManager.GetUserName(User)));
            message.Subject = "Your order";
            message.Body = new TextPart("plain")
            {
                Text = "Hello, This is your order: "
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("testprojecthr@gmail.com", "1.Password");
                client.Send(message);
                client.Disconnect(true);
            }
            return View();

        }
    }
}