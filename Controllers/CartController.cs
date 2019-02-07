using System.Collections.Generic;
using System.Linq;
using WebApp1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.AspNetCore.Identity;
using System.Text;
using DinkToPdf;
using System.IO;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using WebApp1.Models.Database;
using WebApp1.Models.Helper;
using WebApp1.Models.ViewModels;
using FluentValidation.Results;
using System.ComponentModel;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp1.Controllers
{
    public class CartController : Controller
    {
        private readonly WebshopContext _context;
        private UserManager<Users> _userManager;
        private IConverter _converter;
        private readonly IHostingEnvironment _appEnvironment;
        BindingList<string> errors = new BindingList<string>();
        private readonly int maxPageSize = 5;

        public const string SessionKeyName = "cart";
        public string SessionInfo_Name { get; private set; }

        public CartController(WebshopContext context, UserManager<Users> userManager, IConverter converter,
            IHostingEnvironment appEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _converter = converter;
            _appEnvironment = appEnvironment;
        }

        [Route("cart")]
        public IActionResult Index()
        {
            var cart = SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart");
            ViewData["cart"] = cart;

            if (cart == null || cart.ToArray().Length == 0)
            {
                return View("EmptyShoppingCart");
            }
            else
            {
                ViewBag.cart = cart;
                ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
                ViewBag.shippingCost = CalculateShippingCost(ViewBag.total);
                ViewData["cart"] = cart;
            }

            return View();
        }

        public double productPrice(List<Item> cart, int id)
        {
            var total = 1.0;
            if (new Item().Product.DiscountedPrice != -1)
            {
                total = cart.Sum(item => item.Product.DiscountedPrice * item.Quantity);
            }
            else
            {
                total = cart.Sum(item => item.Product.DiscountedPrice * item.Quantity);
            }

            return total;
        }

        public IActionResult plus(int id)
        {
            List<Item> cart = SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart");
            CheckItemInSC(id, cart);
            _context.SaveChanges();
            SessionExtensions.Set(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index", "cart");
        }

        public IActionResult min(int id)
        {
            Product product = _context.Product.Find(id);
            List<Item> cart = SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            product.Quantity += 1;
            _context.SaveChanges();
            if (cart[index].Quantity > 1)
            {
                cart[index].Quantity = cart[index].Quantity - 1;
            }
            else
            {
                cart[index].Quantity = cart[index].Quantity;
            }

            SessionExtensions.Set(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }


        [Route("buy")]
        public IActionResult Buy(int id, int? categoryId, int? pageNumber, string lastAction = "")
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
                _context.SaveChanges();
                SessionExtensions.Set(HttpContext.Session, "cart", cart);
            }

            if (lastAction == "defaultPage")
            {
                return RedirectToAction("Index", "ViewProduct", new { id });
            }

            if (lastAction == "categoryPage")
            {
                return RedirectToAction("Index", "Category", new { categoryId, pageNumber });
            }

            if (lastAction == "filteredPage")
            {
                return RedirectToAction("Filtered", "Category", new { categoryId, pageNumber, useSessionFilters = true });
            }

            return RedirectToAction("Index", "Home");
        }

        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            Product product = _context.Product.Find(id);
            List<Item> cart = SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            product.Quantity += cart[index].Quantity;
            _context.SaveChanges();
            cart.RemoveAt(index);
            SessionExtensions.Set(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private void VoorraadVerminderen(int id)
        {
            Product product = _context.Product.Find(id);
            if (product.Quantity > 0)
            {
                product.Quantity -= 1;
                _context.SaveChanges();
            }
            else
            {
                product.Quantity = 0;
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
                Product product = _context.Product.Find(id);
                if (product.Quantity == 0)
                {
                    RedirectToAction("Index", "Cart");
                }
                else
                {
                    cart[index].Quantity++;
                    VoorraadVerminderen(id);
                }
            }
        }

        private void AddToShoppingCart(int id, List<Item> cart)
        {
            if (_context.Product.Find(id).Quantity > 0)
            {
                var Product1 = _context.Product.Find(id);
                if (Product1.DiscountedPrice != -1)
                {
                    Product1.Price = Product1.DiscountedPrice;
                    cart.Add(new Item { Product = Product1, Quantity = 1 });
                }
                else
                {
                    cart.Add(new Item { Product = Product1, Quantity = 1 });
                }

                VoorraadVerminderen(id);
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

        // [Route("checkOut")]
        public IActionResult checkOut()
        {
            var cart = SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
            if (cart.ToArray().Length == 0)
            {
                return RedirectToAction("Mainpage", "Home");
            }

            return View("checkOut");
        }

        public IActionResult userLoginCheck()
        {
            var currentUser = _userManager.GetUserAsync(User).Result;
            if (currentUser == null)
            {
                return View("askregister", "cart");

            }
            else
            {
                return RedirectToAction("Pay", "cart");
            }
        }
        public static Dictionary<string, string> CountryList()
        {
            //Creating Dictionary
            Dictionary<string, string> cultureList = new Dictionary<string, string>();

            //getting the specific CultureInfo from CultureInfo class
            CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo getCulture in getCultureInfo)
            {
                //creating the object of RegionInfo class
                RegionInfo getRegionInfo = new RegionInfo(getCulture.Name);
                //adding each country Name into the Dictionary
                if (!(cultureList.ContainsKey(getRegionInfo.Name)))
                {
                    cultureList.Add(getRegionInfo.Name, getRegionInfo.EnglishName);
                }
            }
            //returning country list
            return cultureList;

        }

        public IActionResult sendOrderMail()
        {
            var list = new SelectList(CartController.CountryList(), "Key", "Value");
            var sortList = list.OrderBy(p => p.Text).ToList();
            ViewBag.Countries = sortList;
            var cart = SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
            return View("sendOrderMail");
        }
        public IActionResult bestellingPlaatsenUnSub(SubscribeModel model)
        {

            var cart = SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(items => items.Product.Price * items.Quantity);
            ViewBag.total = CalculateShippingCost(ViewBag.total) + ViewBag.total;
            Order order = new Order();
            Product product = new Product();
            AddressValidator validator = new AddressValidator();
            order.Status = "Onderweg";
            order.Date = DateTime.Now;
            var id = order.UserId;
            var email = model.Email;



            // var results = validator.Validate(model);
            // if (results.IsValid == false)
            // {
            //     foreach (ValidationFailure failure in results.Errors)
            //     {
            //         ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
            //         return View("sendOrderMail");

            //         // errors.Add($"{failure.PropertyName}: {failure.ErrorMessage}");
            //     }
            // }
            if (id == null)
            {
                order.email = email;
            }
            else
            {
                id = _userManager.GetUserId(User);
            }
            order.ShippingFee = CalculateShippingCost(cart.Sum(items => items.Product.Price * items.Quantity));
            _context.Add(order);
            _context.SaveChanges();
            foreach (var i in cart)
            {
                OrderDetail orderDetail = new OrderDetail
                {
                    Quantity = i.Quantity,
                    Price = i.Product.Price * i.Quantity,
                    Image = i.Product.Image,
                    Title = i.Product.Title,
                    OrderId = order.Id,
                    ProductId = i.Product.Id
                };
                _context.Add(orderDetail);
                _context.SaveChanges();
            }
            return View("sendOrderMail");

        }

        public void bestellingPlaatsen(SubscribeModel model)
        {
            var cart = SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(items => items.Product.Price * items.Quantity);
            ViewBag.total = CalculateShippingCost(ViewBag.total) + ViewBag.total;
            Order order = new Order();
            Product product = new Product();
            order.Status = "Onderweg";
            order.Date = DateTime.Now;
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                order.email = model.Email;
            }
            else
            {
                order.email = _userManager.GetUserAsync(User).Result.Email;
                order.UserId = _userManager.GetUserAsync(User).Result.Id;
            }
            order.ShippingFee = CalculateShippingCost(cart.Sum(items => items.Product.Price * items.Quantity));
            _context.Add(order);
            _context.SaveChanges();
            foreach (var i in cart)
            {
                OrderDetail orderDetail = new OrderDetail
                {
                    Quantity = i.Quantity,
                    Price = i.Product.Price * i.Quantity,
                    Image = i.Product.Image,
                    Title = i.Product.Title,
                    OrderId = order.Id,
                    ProductId = i.Product.Id
                };
                _context.Add(orderDetail);
                _context.SaveChanges();
            }
        }

        public void increaseQuantity(int id)
        {
            // List<Item> cart = new List<Item>();
            // cart.Add(new Item { Product = _context.Productwaarde.Find(id), Quantity = 1 });
            // BesteldeItem besteldeItem = new BesteldeItem{
            //     besteldeItem.Quantity = 1
            // };
            Product product = _context.Product.Find(id);
            product.Quantity++;
        }

        [Route("QuantityInput/{id}")]
        [HttpPost]
        public int QuantityInput(int changedQuantity, int id)
        {
            Product product = _context.Product.Find(id);
            List<Item> cart = SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart[index].Quantity = changedQuantity;
            _context.SaveChanges();


            // // cart.Add(new Item { Product = _context.Productwaarde.Find(id),  Quantity = changedQuantity });
            // // ViewBag.cart = cart;
            // // ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
            // // ViewData["cart"] = cart;

            // SessionExtensions.Set(HttpContext.Session, "cart", cart);

            return changedQuantity;
        }

        [HttpPost]
        public ActionResult EmailOrder(SubscribeModel model)
        {
            var list = new SelectList(CartController.CountryList(), "Key", "Value");
            var sortList = list.OrderBy(p => p.Text).ToList();
            ViewBag.Countries = sortList;

            if (ModelState.IsValid)
            {
                if (model.Country == null)
                {
                    model.Country = "";
                }
                var email = model.Email;
                var message = new MimeMessage();

                message.From.Add(new MailboxAddress("Banana Boat", "testprojecthr@gmail.com"));
                message.To.Add(new MailboxAddress(email));
                message.Subject = "Your order";
                var builder = new BodyBuilder();
                builder.TextBody = @"Beste klant,
                Bedankt voor je bestelling. 
                Je factuur vind je terug in de bijlage van deze mail.";
                builder.Attachments.Add(_appEnvironment.WebRootPath + "/images/reportPDF/Report.pdf");
                message.Body = builder.ToMessageBody();
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("testprojecthr@gmail.com", "1.TestProjectC");
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            bestellingPlaatsen(model);
            HttpContext.Session.Remove("cart");
            return View("pay");
        }

        [Route("pay")]
        public IActionResult pay(SubscribeModel model)
        {
            var list = new SelectList(CartController.CountryList(), "Key", "Value");
            var sortList = list.OrderBy(p => p.Text).ToList();
            ViewBag.Countries = sortList;


            AddressValidator validator = new AddressValidator();
            var results = validator.Validate(model);
            if (results.IsValid == false)
            {
                foreach (ValidationFailure failure in results.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);

                    // errors.Add($"{failure.PropertyName}: {failure.ErrorMessage}");
                    return View("sendOrderMail");

                }
            }
            var email = _userManager.GetUserName(User);
            if (email == null)
            {
                email = model.Email;
            }


            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Banana Boat", "testprojecthr@gmail.com"));
            message.To.Add(new MailboxAddress(email));
            message.Subject = "Your order";
            var builder = new BodyBuilder();
            builder.TextBody = @"Beste klant,
            Bedankt voor je bestelling. 
            Je facatuur vind je terug in de bijlage van deze mail.";
            builder.Attachments.Add(_appEnvironment.WebRootPath + "/images/reportPDF/Report.pdf");
            message.Body = builder.ToMessageBody();
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("testprojecthr@gmail.com", "1.TestProjectC");
                client.Send(message);
                client.Disconnect(true);
            }
            bestellingPlaatsen(model);

            HttpContext.Session.Remove("cart");
            return View();
        }


        public string GetHTMLString()
        {
            var cart = SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'>
                                <br>
                                <h1>Beste klant,
                                <br>
                                Bedankt voor je bestelling. 
                                <br>
                                Hieronder vind je je factuur terug.
                                </h1></div>
                                <br>
                                <table align='center'>
                                    <tr>
                                        <th>Artikel</th>
                                        <th>Aantal</th>
                                        <th>Prijs</th>
                                        <th>Subtotaal</th>
                                    </tr>");

            foreach (var emp in ViewBag.cart)
            {
                var total = emp.Product.Price * emp.Quantity;
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                  </tr>", emp.Product.Title, emp.Quantity, emp.Product.Price,
                    emp.Product.Price * emp.Quantity);
            }

            sb.AppendFormat(@"<tr >
                                    <td align='right' colspan='5'>{0}</td>
                                    <td>{1}</td>
                                  </tr>", "Totaal", @ViewBag.total);

            sb.Append(@"
            
                                </table>
                            </body>
                        </html>");

            return sb.ToString();
        }

        [HttpGet]
        public IActionResult CreatePDF()
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = @_appEnvironment.WebRootPath + "/images/reportPDF/Report.pdf"
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = GetHTMLString(),
                WebSettings =
                {
                    DefaultEncoding = "utf-8",
                    UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css")
                },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            var file = _converter.Convert(pdf);
            _converter.Convert(pdf);

            // return File(file, "application/pdf");
            return RedirectToAction("checkOut", "Cart");
        }

        /// <summary>
        /// Calculate the shipping cost based on the total price!
        /// If price is less than 5, costs will be zero.
        /// The shopping costs will be 10% of the total price with a max of 100
        /// </summary>
        /// <param name="totalPrice">Total price of the order</param>
        /// <returns>shipping cost</returns>
        private double CalculateShippingCost(double totalPrice)
        {
            if (totalPrice < 5) return 0;

            double shipping;
            if (totalPrice * 0.1 > 100)
            {
                shipping = 100;
            }
            else
            {
                shipping = totalPrice * 0.1;
            }

            return shipping;
        }
    }
}