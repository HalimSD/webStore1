using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using WebApp1.Models;
using WebApp1.Models.Database;

namespace WebApp1.Controllers.Admin
{
    [Route("/Admin/[controller]/")]
    public class UsersController : Controller
    {
        private readonly WebshopContext context;
        private readonly int maxPageSize = 20;

        public UsersController(WebshopContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var x = new List<Users> ();
            return View(x);
        }
    }
}