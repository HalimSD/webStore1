using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class interactiveImg : Controller
    {

        private readonly WebshopContext _context;

        public interactiveImg(WebshopContext context)
        {
            _context = context;
        }
        [Route("interactiveImg")]
        public IActionResult Index()
        {
             var parent1 = (from soort in _context.Productsoort join parent in _context.ParentChild
                            on soort.Id  equals parent.ParentId
                            where soort.Id == parent.ParentId
                            select soort).ToList().Distinct();

            // var childx = (from child in _context.ParentChild join child1 in _context.ParentChild
            // on child.ParentId equals child1.ChildId where child.ParentId == -1 
            // select new {
            //     parentx = (from parent in _context.ParentChild where parent.ParentId != child.ChildId select parent)
            // }
            // ).ToList().Distinct();
                            
                    //         where p.Parent == null 
                    //         select p.Child;
                    //         var x = parent.FirstOrDefault().Children;

                    //          from productsoorten in _context.Productsoort
                    // join atributen in _context.Attribuutsoort on productsoorten.Id equals atributen.ProductsoortId
                    // where productsoorten.Naam == productsoortt
                    // select atributen;
//             List<ParentChild> parentChild = _context.ParentChild.ToList();
//             // List<Productwaarde> productwaarde = _context.Productwaarde.ToList();
//             Productsoort productsoort = new Productsoort();
//             productsoort.Children = parentChild;
//             // MultiData finalItem = new MultiData();
//             // finalItem.parentChild = parentChild;
//             // finalItem.soort = productsoort;
//             // finalItem.waarde = productwaarde;
           
// var x= productsoort.Children.Select(l=>l.Parent).Where(klaas=>klaas.Id==klaas.Id);
            return View(parent1);
        }

        public IActionResult child(int id)
        {
            var child1 = (from soort in _context.Productsoort join parent in _context.ParentChild
                            on soort.Id  equals parent.ChildId
                            where id == parent.ParentId
                            select soort).ToList().Distinct();
            // from p in _context.ParentChild
            //                 where p.Child != null 
            //                 && p.ChildId == id
            //                 select p.Child;
            
            //  var parent = from p in _context.ParentChild
            //                 where p.Parent != null 
            //                 && p.ParentId == id
            //                 select p.Parent;
            //                 if(child == parent){
            //                     var l =child.Select(x=>x.Id);
            //                     l = parent.Select(x=>x.Id);
            //                     return View("Index");
            //                 }
            return View(child1);
        }

         [Route("parent/{id}")]
        public IActionResult parent(int id)
        {
             var parent1 = (from soort in _context.Productsoort join parent in _context.ParentChild
                            on soort.Id  equals parent.ParentId
                            where id == parent.ChildId
                            select soort).ToList().Distinct();


            //  var parent1 = (from soort in _context.Productsoort join parent in _context.ParentChild
            //                 on soort.Id  equals parent.ChildId
            //                 where id == parent.ChildId
            //                 select soort).ToList().Distinct();

            // var parent = from p in _context.ParentChild
            //                 where p.Parent != null 
            //                 && p.ParentId == id
            //                 select p.Parent;
                            return View(parent1);

        }
        
    }
}


// using System.Collections.Generic;
// using System.Linq;
// using Microsoft.AspNetCore.Mvc;
// using WebApp1.Models;

// namespace WebApp1.Controllers
// {
//     public class interactiveImg : Controller
//     {

//         private readonly WebshopContext _context;

//         public interactiveImg(WebshopContext context)
//         {
//             _context = context;
//         }
//         [Route("interactiveImg")]
//         public IActionResult Index()
//         {
//             var soort = _context.Productsoort;
//             // .OrderBy(x => x.Naam);
//             // .Take(8);         
//             return View(soort);
//         }
//         // [Route("interactiveImg/{id}")]
//         // public IActionResult catSelector(int id)
//         // {
//         //     var waarde = from x in _context.Productwaarde where x.ProductsoortId == id select x;
//         //     return View(waarde.ToList());
//         // }
//         // public ActionResult IndexViewModel()
//         // {
//         //     ViewModelInteractiveImage mymodel = new ViewModelInteractiveImage();
//         //     mymodel.Productsoort = GetTeachers();
//         //     mymodel.Productwaarde = GetStudents();
//         //     return View(mymodel);
//         // }

//     }
// }
