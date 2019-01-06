using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class FooterPages : Controller
    {
       
        public IActionResult Bestellen()
        {
            return View("Bestellen");
        }
        public IActionResult Betalen()
        {
            return View("Betalen");
        }
        public IActionResult Contact()
        {
            return View("Contact");
        }
        public IActionResult Garantie()
        {
            return View("Garantie");
        }
        public IActionResult Klantenservice()
        {
            return View("Klantenservice");
        }
        public IActionResult Leveren()
        {
            return View("Leveren");
        }
        public IActionResult Over()
        {
            return View("Over");
        }
        public IActionResult Retourneren()
        {
            return View("Retourneren");
        }
        public IActionResult Voordelen()
        {
            return View("Voordelen");
        }
    }
}