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
using Microsoft.AspNetCore.Session;

namespace WebApp1.Controllers
{


    public class CartController : Controller
    {
        private readonly WebshopContext _context;
        private UserManager<Users> _userManager;

        public const string SessionKeyName = "cart";
        public string SessionInfo_Name { get; private set; }

        public CartController(WebshopContext context, UserManager<Users> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [Route("cart")]
        public IActionResult Index()
        {
            var cart = SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart");
            ViewData["cart"] = cart;

            if (cart == null)
            {
                return View("EmptyShoppingCart");
            }
            else
            {
                ViewBag.cart = cart;
                ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
                ViewData["cart"] = cart;

            }
            return View();
        }


        [Route("buy")]
        public IActionResult Buy(int id)
        {
            if (SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                AddToShoppingCart(id, cart);
                SessionExtensions.Set(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart");
                CheckItemInSC(id, cart);
                VoorraadVerminderen(id);
                _context.SaveChanges();
                SessionExtensions.Set(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Mainpage", "Home");
        }

        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            Productwaarde productwaarde = _context.Productwaarde.Find(id);
            List<Item> cart = SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            productwaarde.Quantity += cart[index].Quantity;
            _context.SaveChanges();
            cart.RemoveAt(index);
            SessionExtensions.Set(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }
        private void VoorraadVerminderen(int id)
        {
            Productwaarde productwaarde = _context.Productwaarde.Find(id);
            if (productwaarde.Quantity > 0)
            {
                productwaarde.Quantity -= 1;
                _context.SaveChanges();

            }
            else
            {
                productwaarde.Quantity = 0;
                _context.SaveChanges();
            }
        }

        private void CheckItemInSC(int id, List<Item> cart)
        {
            int index = isExist(id);
            if (index == -1)
            {
                AddToShoppingCart(id, cart);
            }
            else
            {
                Productwaarde productwaarde = _context.Productwaarde.Find(id);
                if (productwaarde.Quantity == 0)
                {
                    RedirectToAction("Index", "Cart");
                }
                else
                {
                    cart[index].Quantity++;
                }
            }
        }

        private void AddToShoppingCart(int id, List<Item> cart)
        {
            if (_context.Productwaarde.Find(id).Quantity > 0)
            {
                cart.Add(new Item { Product = _context.Productwaarde.Find(id), Quantity = 1 });
            }
            else
            {
                RedirectToAction("Index", "Cart");
            }
        }
        private void SetSession()
        {
            List<Item> cart = new List<Item>();
            SessionExtensions.Set(HttpContext.Session, "cart", cart);
        }
        private void GetSession()
        {
            SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart");
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

        [Route("checkOut")]
        public IActionResult checkOut()
        {
            var cart = SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                return RedirectToAction("Mainpage", "Home");
            }
            else
            {
                ViewBag.cart = cart;
                ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
                if (_userManager.GetUserName(User) == null)
                {
                    return View("sendOrderMail");
                }
            }
            return View("checkOut");
        }

        [HttpPost]
        public ActionResult EmailOrder (SubscribeModel model)
        {
            if (ModelState.IsValid)
            {
                var email = model.Email;
                var message = new MimeMessage();

                message.From.Add(new MailboxAddress("Halim", "testprojecthr@gmail.com"));
                message.To.Add(new MailboxAddress(email));
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
            }

            return View("pay");
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