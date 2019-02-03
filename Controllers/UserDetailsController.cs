using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;
using WebApp1.Models.Database;

namespace WebApp1.Controllers{

    public class UserDetails : Controller{

        private readonly WebshopContext _context;
        public UserDetails (WebshopContext context, UserManager<Users> userManager){
            _context = context;
        }

        [Route("UserDetails")]
        public IActionResult Index(){
            

            return View();

        }

    }
}
