using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models;
using System.Data;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using WebApp1.Models.Database;
using WebApp1.Models.ViewModels;

namespace WebApp1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly WebshopContext _context;
        private readonly IHostingEnvironment _appEnvironment;
        public const string SessionKeyName = "_Name";
        public string SessionInfo_Name { get; private set; }

        public ProductsController(WebshopContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Category.ToListAsync());
        }

         public IActionResult Indexproductwaarde()
         {
             List<Product> products = _context.Product.ToList();
             List<string> attributeNames = new List<string>();

             foreach (Product item in products)
             {
                 string res =
                 (
                     from ps in _context.Category
                     where ps.Id == item.CategoryId
                     select ps.Naam
                 ).FirstOrDefault();
                 attributeNames.Add(res);
             }

            ViewBag.products = products;
            ViewBag.attributeNames = attributeNames;
            return View();
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Category
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Products/Create
        public IActionResult Create(int? message)
        {
            if (message == 1){
                ViewData["message"] = "Kies een unieke productsoort naam";
            }
            else if (message == 2){
                ViewData["message"] = "Kies een geldig attribuut";
            }
            else if (message == 3){
                ViewData["message"] = "Vink een checkbox aan";
            }
            else if (message == 4){
                ViewData["message"] = "Geef een geldig afbeeldingsformaat: png,jpg,jpeg,gif";
            }
            var parents = from m in _context.Category select new WebApp1.Models.AddCategory.Parent(){Categories = m, selected = false };
            var childs = from m in _context.Category select new WebApp1.Models.AddCategory.Child(){Categories = m, selected = false };
             var main = new WebApp1.Models.AddCategory();
                                main.parents = parents.ToList();
                                main.children  = childs.ToList();

            return View(main);
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category, List<WebApp1.Models.AddCategory.Parent> parents )
        {
             //if (ModelState.IsValid)
            //{
                if(category.Naam == null){
                    return RedirectToAction("Create", new{message = 1});
                }
                //check of productsoort bestaat
                var productsoortexists = from p in _context.Category where p.Naam == category.Naam select p;
                if (productsoortexists.Any()){
                        return RedirectToAction("Create", new{message = 1});
                    } 
                //check of attribute is empty
                 if (category.AttributeType != null){
                     
                    foreach(var item in category.AttributeType){
                            if(item.Name == null){
                                return RedirectToAction("Create",new {message = 2 });
                            }
                        }
                 }
                
                //check for empty parent
                if (parents.Count()>0){ 
                    var parentlistempty = true;
                    for (var i = 0; i<parents.Count(); i++ ){
                        if(parents[i].selected == true){
                            parentlistempty = false;
                        }
                    }
                    if (parentlistempty == true){
                        return RedirectToAction("Create", new{message = 3});
                    }
                }
               
            
                // check attribuut dubbel in lijst
                if(category.AttributeType!= null){ var attribuutinlijst = category.AttributeType
                                   .GroupBy(e => e.Name)
                                   .Any(e => e.Count() > 1);
                                   
                                   if(attribuutinlijst)
                                    {
                                        return RedirectToAction("Create", new{message = 2});
                                    }
                }
              
                
                
                
            

            var files = HttpContext.Request.Form.Files;
            foreach (var Image in files)
            {
                if (Image != null && Image.Length > 0)
                {
                    var file = Image;
                     if (Path.GetExtension(file.FileName).ToLower() != ".jpg"
                            && Path.GetExtension(file.FileName).ToLower() != ".png"
                            && Path.GetExtension(file.FileName).ToLower() != ".gif"
                            && Path.GetExtension(file.FileName).ToLower() != ".jpeg")
                            {
                                 return RedirectToAction("Create", new{message = 4});
                            }
                    //There is an error here
                    var uploads = Path.Combine(_appEnvironment.WebRootPath, "images" + Path.DirectorySeparatorChar + "products");
                    if (file.Length > 0)
                    {
                        var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                        using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                            category.Image = fileName;
                        }

                    }
                }
            }

                if (category.Image == null)
                {
                    category.Image = "default.png";
                }
                _context.Category.Add(category);


                try
                    {
                     await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateException e)
                    {
                    //This either returns a error string, or null if it can’t handle that error
                    return NotFound();
                    }
               
            

            var productsoortid = from p in _context.Category where p.Naam == category.Naam select p;
            productsoortid.First();
            

             var selectedparents = new List<Category>();
                for (var i = 0; i<parents.Count(); i++ ){
                    if(parents[i].selected == true){
                        selectedparents.Add(parents[i].Categories);
                    }
                }
                 foreach(var parent in selectedparents){  
                var parentchild = new ParentChild();
                        parentchild.ParentId = parent.Id;
                        parentchild.ChildId =  productsoortid.First().Id;
                        _context.ParentChild.Add(parentchild);
                 }

                 
                    await _context.SaveChangesAsync();
                 

           
           
                //}
               return RedirectToAction("Index", "CategoryList");

            }
            
        

        public IActionResult Create2(int? message, string at)
        {
            
            if (message == 1){
                ViewData["message"] = "Kies een unieke productnaam";
            }
            else if (message == 2){
                ViewData["message"] = "Attribuutnaam staat al in de lijst ";
            }
            
            else if (message == 3){
                ViewData["message"] = "Geef een geldige afbeelding in: png,jpg,jpeg,gif";
            }
            else if (message == 4){
                ViewData["message"] = "De waarde moet een getal zijn van attribuut: ";
            }
            else if (message == 9){
                ViewData["message"] = "De Prijs moet positief zijn";
            }
            else if (message == 10){
                ViewData["message"] = "De kwantiteit moet positief zijn";
            }
            else if (message == 11){
                ViewData["message"] = "Attribuutwaarde mag niet leeg zijn: ";
            }

            if(at != null){
              ViewData["message"] = ViewData["message"] + at; 
            }
            var myList = new List<string>();
            var productsoorten = from m in _context.Category select new { m.Naam };


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




         public IActionResult Create3(string productsoortt)
        {
            if (string.IsNullOrEmpty(productsoortt)) {
                return RedirectToAction("Create2");
            }   
             var productsoortid =
                    from productsoorten in _context.Category
                    where productsoorten.Naam == productsoortt 
                    select productsoorten;

             var standardattributen =
                    from productsoorten in _context.Category
                    join atributen in _context.AttributeType on productsoorten.Id equals atributen.CategoryId
                    where productsoorten.Naam == productsoortt && atributen.Custom == false
                    select atributen;
            var id = productsoortid.First().Id;
            
            // var alreadyattributencustomproductsoort =
            //         from productsoorten in _context.Productsoort
            //         join atributen in _context.Attribuutsoort on productsoorten.Id equals atributen.ProductsoortId
            //         where atributen.Custom == true && productsoorten.Naam == productsoortt
            //         select new CreateproductModel.CreateproductModel.AlreadyCustomAtributes(){customAtribute = atributen, selected = false};
            
            var alreadyattributencustomall =
                    from productsoorten in _context.Category
                    join atributen in _context.AttributeType on productsoorten.Id equals atributen.CategoryId
                    where atributen.Custom == true
                    group atributen by productsoorten into g
                    select g;

                    var customats = new List<CreateproductModel.CreateproductModel.AllCustomAtt>(){};
                    foreach(var g in alreadyattributencustomall) {
                        var at = new CreateproductModel.CreateproductModel.AllCustomAtt();
                        at.customAtributes = new List<CreateproductModel.CreateproductModel.AtwthBool>(){};
                        at.productSoort = g.Key;
                        foreach (var v in g) {
                           at.customAtributes.Add(new CreateproductModel.CreateproductModel.AtwthBool(){customAtribute = v , selected = false});
                        }
                        customats.Add(at);
                        }
                    
    

                    
                    // var b = new CreateproductModel.CreateproductModel.AllCustomAtt(){productSoort = g.Key, customAtributes = new CreateproductModel.CreateproductModel.AtwthBool(){customAtribute = g.ToList() , selected = false), selected = false};
           

            var ProductModel = new WebApp1.CreateproductModel.CreateproductModel();
                    ProductModel.Attribuutsoorts = standardattributen.ToList();
                    ProductModel.AcustomAtributesall = customats;
                    // ProductModel.AcustomAtributesproductsoort = alreadyattributencustomproductsoort.ToList();
                    ProductModel.Product = new Product(){Id = id}; 

            return View(ProductModel);
            
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
       // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create3(Product product, IList<AttributeType> Attribuutsoorts, IList<CreateproductModel.CreateproductModel.Atribuutsoortmetwaardes> newcustom, IList<CreateproductModel.CreateproductModel.AllCustomAtt> AcustomAtributesall)
        {
            

            
                if (product.Title == null){
                    return RedirectToAction("Create2",new {message = 1});
                }
                if(product.Price<0){
                    return RedirectToAction("Create2", new{message = 9});
                }
                if(product.Quantity<0){
                    return RedirectToAction("Create2", new{message = 10});
                }

                for(var i=0; i<Attribuutsoorts.Count; i++){
                        if(Attribuutsoorts[i].Type == "number"){
                                bool isDouble = Double.TryParse(Attribuutsoorts[i].AttributeValues[0].Waarde, out double n );
                                if(!isDouble) {
                                    return RedirectToAction("Create2",new { message = 4, at = Attribuutsoorts[i].Name });
                                }
                            }
                 }

                
               
                //check of productwaarde al bestaat
                var productwaardeextists = from p in _context.Product where p.Title == product.Title select p;
                    if (productwaardeextists.Any()){
                        return RedirectToAction("Create2",new { message = 1});
                    } 
                //check of attribuutsoort al bestaat
                // foreach(var item in newcustom){
                //     var attributeexists = from a in _context.Attribuutsoort where a.Attrbuut == item.extraAtribute.Attrbuut select a;
                //     if (attributeexists.Any()){
                //          return RedirectToAction("Create2",new { message = 2});
                //     } 
                // }

                 // check attribuut dubbel in lijst
               var attribuutinlijst = newcustom
                                   .GroupBy(e => e.extraAtribute.Name)
                                   .Any(e => e.Count() > 1);
                if(attribuutinlijst)
                {
                        return RedirectToAction("Create2", new{message = 2});
                }

            
           

            var files = HttpContext.Request.Form.Files;
            foreach (var Image in files)
            {
                if (Image != null && Image.Length > 0)
                {
                    var file = Image;
                    if (Path.GetExtension(file.FileName).ToLower() != ".jpg"
                            && Path.GetExtension(file.FileName).ToLower() != ".png"
                            && Path.GetExtension(file.FileName).ToLower() != ".gif"
                            && Path.GetExtension(file.FileName).ToLower() != ".jpeg")
                            {
                                 return RedirectToAction("Create2", new{message = 3});
                            }
                    //There is an error here
                    var uploads = Path.Combine(_appEnvironment.WebRootPath, "images" + Path.DirectorySeparatorChar + "products");
                    if (file.Length > 0)
                    {
                         
                        var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                        using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                            product.Image = fileName;
                        }

                    }
                }
            }

                if (product.Image == null)
                {
                    product.Image = "default.png";
                }
                _context.Product.Add(product); 
                await _context.SaveChangesAsync();

             foreach(var item in Attribuutsoorts){
                if(item.AttributeValues[0].Waarde == null){
                     _context.Product.Remove(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Create2",new {message = 11, at = item.Name});
                }
                else{
                var productwaardeid = from p in _context.Product where p.Title == product.Title select p;
                var standardatt = new AttributeValue(){Waarde = item.AttributeValues[0].Waarde, ProductId = productwaardeid.First().Id, AttributeTypeId = item.AttributeValues[0].AttributeTypeId};
                _context.AttributeValue.Add(standardatt); 
                    await _context.SaveChangesAsync();
                    }
             }

            foreach(var item in AcustomAtributesall){ 
                for (var i = 0; i<item.customAtributes.Count; i++){
                    if(item.customAtributes[i].selected == true){
                    var productwaardeid = from p in _context.Product where p.Title == product.Title select p;
                         if(item.cattribuutwaarde[i].Waarde == null){
                              _context.Product.Remove(product);
                            await _context.SaveChangesAsync();
                            return RedirectToAction("Create2",new {message = 2, at = item.customAtributes[i].customAtribute.Name});
                            }
                        if(item.customAtributes[i].customAtribute.Type == "number"){
                                bool isDouble = Double.TryParse(item.cattribuutwaarde[i].Waarde, out double n );
                                if(!isDouble) {
                                     _context.Product.Remove(product);
                                    await _context.SaveChangesAsync();
                                    return RedirectToAction("Create2",new { message = 4, at = item.customAtributes[i].customAtribute.Name});
                                }
                            }
                        var atributeID = from p in _context.AttributeType where p.Id == item.customAtributes[i].customAtribute.Id select p;
                        var customatwaarde = new AttributeValue(){Waarde = item.cattribuutwaarde[i].Waarde, ProductId = productwaardeid.First().Id, AttributeTypeId = atributeID.First().Id};
                    _context.AttributeValue.Add(customatwaarde) ; 
                    
                    }
                    await _context.SaveChangesAsync(); 
                    }
                }   
            
            

            // foreach(var item in AcustomAtributesproductsoort){ 
            //     if (item.selected == true){
            //         if(item.cattribuutwaarde.Waarde == null){
            //                 return RedirectToAction("Create2",new { message = 2});
            //                 }
            //         var atributeID = from p in _context.Attribuutsoort where p.Id == item.customAtribute.Id select p;
            //         var productwaardeid = from p in _context.Productwaarde where p.Title == productwaarde.Title select p;

            //         var customatwaarde = new Attribuutwaarde(){Waarde = item.cattribuutwaarde.Waarde, ProductwaardeId = productwaardeid.First().Id, AttribuutsoortId = atributeID.First().Id};
            //         _context.Attribuutwaarde.Add(customatwaarde); 
            //         await _context.SaveChangesAsync(); 
            //      }
            // }


            foreach(var item in newcustom){ 
                if(item.extraAtributewaarde.Waarde == null){
                            _context.Product.Remove(product);
                            await _context.SaveChangesAsync();
                            return RedirectToAction("Create2",new { message = 2});
                }
                if(item.extraAtribute.Type == "number"){
                     bool isDouble = Double.TryParse(item.extraAtributewaarde.Waarde, out double n );
                                if(!isDouble) {
                                     _context.Product.Remove(product);
                                    await _context.SaveChangesAsync();
                                    return RedirectToAction("Create2",new { message = 4, at = item.extraAtribute.Name});
                                }
                }
                
                var customat = new AttributeType(){Name = item.extraAtribute.Name, Type= item.extraAtribute.Type, Custom= true,CategoryId= product.CategoryId};
                 _context.AttributeType.Add(customat);
                 await _context.SaveChangesAsync();

                 var atributeID = from p in _context.AttributeType where p.Id == customat.Id select p;
                var productwaardeid = from p in _context.Product where p.Title == product.Title select p;

                 var customatwaarde = new AttributeValue(){Waarde = item.extraAtributewaarde.Waarde, ProductId = productwaardeid.First().Id, AttributeTypeId = atributeID.First().Id};
                 _context.AttributeValue.Add(customatwaarde); 
                 await _context.SaveChangesAsync(); 
            }
                return RedirectToAction("index", "CategoryList");
           
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

            var products = await _context.Category.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Price")] Product products)
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

            var products = await _context.Category
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
            var products = await _context.Category.FindAsync(id);
            _context.Category.Remove(products);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
            return _context.Category.Any(e => e.Id == id);
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

          public IActionResult ChooseProductsoort(int? m)
        {
            if(m == 1){
                ViewData["message"] = "De productsoortnaam bestaat al";
            }
             if(m == 2){
                ViewData["message"] = "Vul de attributen in";
            }
           
            var model = new WebApp1.Models.EditproductsoortModel();
            var productsoorts = from p in _context.Category select p;
            model.productsoorts = productsoorts.ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
         public IActionResult ChooseProductsoort(WebApp1.Models.EditproductsoortModel m)
        {
            if(m.productsoort == null){
               return RedirectToAction("ChooseProductsoort");
            }
            var p = m.productsoort;
            return RedirectToAction("Editproductsoort", new{oldproductsoort = p });
        }

        public IActionResult Editproductsoort(WebApp1.Models.EditproductsoortModel2 m )
        {
            if (m.oldproductsoort ==null ){
                return RedirectToAction("ChooseProductsoort");
            }
            
           
            else if(m.newproductsoort!=null&& m.oldproductsoort!=null){
                var result = _context.Category.SingleOrDefault(p => p.Naam == m.oldproductsoort);
                var ats = from a in _context.AttributeType where a.Category.Naam == m.oldproductsoort select a;
                var lsitat = ats.ToList();
                if(m.newproductsoort != m.oldproductsoort){
                    var productsoortex = from p in _context.Category where p.Naam == m.newproductsoort select p;
                    if(productsoortex.Any()){
                        return RedirectToAction("ChooseProductsoort", new{m = 1}); 
                    }
                }
                if(m.atributes !=null){
                    foreach(var item in m.atributes){
                    if (item.Name==null){
                        return RedirectToAction("ChooseProductsoort", new{m = 2}); 
                    }
                }
                result.Naam = m.newproductsoort;
                for (var a =0; a<lsitat.Count; a++)
                {
                    for (var b=0; b<m.atributes.Count; b++)
                    {
                        if (lsitat[a].Id == m.atributes[b].Id)
                        {
                             lsitat[a].Name = m.atributes[b].Name;
                        }
                    }
                }

                }
                
                
                //_context.Update(ats);
                //_context.Productsoort.Add(result);
                _context.SaveChanges();
                return RedirectToAction("ChooseProductsoort");
            }

            else {
                var getattributen = from at in _context.AttributeType where at.Category.Naam == m.oldproductsoort select at;
                var model = new WebApp1.Models.EditproductsoortModel2();
                model.atributes = getattributen.ToList();
                model.oldproductsoort = m.oldproductsoort;
                return View(model);
            }   
            
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

