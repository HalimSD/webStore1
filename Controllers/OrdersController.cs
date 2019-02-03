using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using WebApp1.Models;
using WebApp1.Models.Database;
using WebApp1.Models.Helper;

namespace WebApp1.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly int maxPageSize = 3;
        private readonly WebshopContext context;
        private readonly UserManager<Users> userManager;
        
        public OrdersController(WebshopContext context, UserManager<Users> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public IActionResult Index(int pageNumber = 1)
        {
            return View();
        }
        
        public IActionResult Details(int id)
        {
            var x = id;
            List<OrderDetail> besteldeItem = new List<OrderDetail>();
            besteldeItem = (from b in context.OrderDetail
                    where b.OrderId == id
                    select new OrderDetail
                    {
                        Id = b.Id,
                        Title = b.Title,
                        Price = b.Price,
                        Quantity = b.Quantity,
                        Image = b.Image
                    }
                ).ToList();

            ViewBag.besteldeItem = besteldeItem;
            ViewBag.shippingFee = (from b in context.Order where b.Id == id select b.ShippingFee)
                .FirstOrDefault();

            return View();
        }
        
        public JsonResult GetData(int pageIndex=1)
        {          
            // Helper object used to generate a page model
            PaginationHelper<Order>
                pagination = new PaginationHelper<Order>(maxPageSize, context.Order);

            // Prepare a query that we will pass to the pagination helper
            IQueryable<Order> query = (
                from x in context.Order
                where x.UserId == userManager.GetUserId(User)
                select x
            );
            // Let the pagination helper build a page model and pass it to the view
            PaginationViewModel<Order> model = pagination.GetPageIQueryable(pageIndex, query);
            
            return new JsonResult(model);
        }
        
        public JsonResult GetDataFiltered(string id="", string date="", string status="", int pageIndex=1)
        {
            // Create a PaginationHelper instance. It will be used to generate a page
            PaginationHelper<Order> pagination = new PaginationHelper<Order>(maxPageSize,context.Order);

            bool filterOnDate = false;
            DateTime dateValue = DateTime.Now;
            
            // Some error checking as JS may give null values!
            if (id == null) { id = ""; }
            if (status == null) { status = ""; }

            if (date != "")
            {
                filterOnDate = DateTime.TryParse(date, out dateValue);
            }

            // Since the pagination helper doesn't have built-in filtering,
            // we'll have to prepare a custom filtered query and pass it to the helper
            IQueryable<Order> query = (
                from x in context.Order
                where x.UserId == userManager.GetUserId(User) &&
                      x.Id.ToString().Contains(id) &&
                      x.Status.ToUpper().Contains(status.ToUpper())
                select x
            );

            if (filterOnDate)
            {
                query = (
                    from x in query
                    where x.Date.Year == dateValue.Year &&
                          x.Date.Month == dateValue.Month &&
                          x.Date.Day == dateValue.Day
                    select x
                );
            }
                      
            PaginationViewModel<Order> json = pagination.GetPageIQueryable(pageIndex, query);
            
            // Encode to JSON and return it
            return new JsonResult(json);
        }
    }
}