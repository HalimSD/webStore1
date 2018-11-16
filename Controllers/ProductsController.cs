using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp1.products;
using WebApp1.Models;
using System.Data;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
namespace WebApp1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly WebshopContext _context;
        public const string SessionKeyName = "_Name";
        public string SessionInfo_Name { get; private set; }

        public ProductsController(WebshopContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Products/Create
        public IActionResult Create()
        {

            ViewData["kaas"] = "1";

            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Productsoort productsoort)
        {
            if (ModelState.IsValid)
            {
                _context.Productsoort.Add(productsoort);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(productsoort);
        }


        public IActionResult Create2()
        {
            var myList = new List<string>();
            var productsoorten = from m in _context.Productsoort select new { m.Naam };


            foreach (var product in productsoorten)
            {
                myList.Add(product.ToString());
                Console.WriteLine(product.Naam);
            }
            var myArray = myList.ToArray();
            ViewData["productsoorten"] = myArray;
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create2(string hi)
        {
            if (hi == null)
            {
                return NotFound();
            }

            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                HttpContext.Session.SetString(SessionKeyName, "kaas");

            }
            HttpContext.Session.SetString("Test", hi);
            var kaas = HttpContext.Session.GetString("Test");
            Console.WriteLine(kaas);

            return RedirectToAction("Create3");
        }




        public IActionResult Create3()
        {
            var product_id_int = 0;
            var AttribuutsoortID = new List<int>();
            var attributes = new List<string>();
            var productsoortnaam = HttpContext.Session.GetString("Test");
            Console.WriteLine(productsoortnaam);
            var productsoort = from m in _context.Productsoort where m.Naam == productsoortnaam select new { m.Id };
            foreach (var productsoortje in productsoort)
            {
                product_id_int = productsoortje.Id;
            }
            var attribuutsoort = from a in _context.Attribuutsoort where a.ProductsoortId == product_id_int select new { a.Attrbuut, a.Id };
            foreach (var attribute in attribuutsoort)
            {
                attributes.Add(attribute.Attrbuut.ToString());
                AttribuutsoortID.Add(attribute.Id);
            }
            var Attributen = attributes.ToArray();
            var AttribuutsoortIDs = AttribuutsoortID.ToArray();
            HttpContext.Session.Set<String[]>("Attributen", Attributen);
            HttpContext.Session.Set<int>("productsoortid", product_id_int);
            HttpContext.Session.Set<int[]>("AttribuutsoortID", AttribuutsoortIDs);

            //var hi = HttpContext.Session.Get<String[]>("Attributen");
            // Console.WriteLine(hi[0]);
            //Console.WriteLine(myArray);
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create3(Productwaarde productwaarde)
        {

            if (ModelState.IsValid)
            {
                _context.Productwaarde.Add(productwaarde);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View();
        }





        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.




        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Price")] Products products)
        {
            if (id != products.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(products);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var products = await _context.Products.FindAsync(id);
            _context.Products.Remove(products);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
        private int favExists(int id)
        {
            List<Item> fav = SessionExtensions.Get<List<Item>>(HttpContext.Session, "fav");
            for (int i = 0; i < fav.Count; i++)
            {
                if (fav[i].Product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
        // [HttpPost]
        // public JsonResult _Fav(int ID)
        // {
        //     List<string> errors = new List<string>(); // You might want to return an error if something wrong happened

        //     //Do DB Processing   

        //     return Json(errors, JsonRequestBehavior.AllowGet);
        // }

        // [HttpPost]
        // public JsonResult _UnFav(int ID)
        // {
        //     List<string> errors = new List<string>(); // You might want to return an error if something wrong happened

        //     //Do DB Processing   

        //     return Json(errors, JsonRequestBehavior.AllowGet);
        // }

        // public Action fav(int id)
        // {
        //     Productwaarde productModel = new Productwaarde();
        //     if (SessionExtensions.Get<List<Item>>(HttpContext.Session, "fav") == null)
        //     {
        //         List<Item> fav = new List<Item>();
        //         fav.Add(new Item { Product = _context.Productwaarde.Find(id), Quantity = 1 });
        //         SessionExtensions.Set(HttpContext.Session, "fav", fav);
        //     }
        //     else
        //     {
        //         List<Item> fav = SessionExtensions.Get<List<Item>>(HttpContext.Session, "fav");
        //         int index = favExists(id);
        //         if (index != -1)
        //         {
        //             fav[index].Quantity++;
        //         }
        //         else
        //         {
        //             fav.Add(new Item { Product = _context.Productwaarde.Find(id), Quantity = 1 });
        //         }
        //         SessionExtensions.Set(HttpContext.Session, "fav", fav);
        //     }
        //     return Json();
        // }

    }
}
