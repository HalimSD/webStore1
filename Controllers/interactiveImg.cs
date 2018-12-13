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
            var soort= _context.Productsoort.ToList().OrderBy(x => x.Naam).Take(2);
            // .Take(8);
          
            return View(soort);
        }

        [Route("interactiveImg/{id}")]
        public IActionResult child(int id)
        {
            var soort= _context.Productsoort.Find(id);
            // ..ToList().OrderBy(x => x.Naam).Take(2);
            // .Take(8);
          
            return View(soort);
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
