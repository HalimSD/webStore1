using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using WebApp1.Models;

namespace WebApp1.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    [Route("/Admin/[controller]/")]
    public class OrderListController : Controller
    {
        private readonly WebshopContext context;
        private readonly IHostingEnvironment appEnvironment;
        private readonly int maxPageSize = 20;

        public OrderListController(WebshopContext context, IHostingEnvironment appEnvironment)
        {
            this.context = context;
            this.appEnvironment = appEnvironment;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("EditStatus")]
        public IActionResult EditStatus(int? id)
        {
            if (id == null) return NotFound();

            OrderListViewModel model =
            (
                from b in context.Bestelling
                from u in context.Users
                where b.BestellingId == id && 
                      b.UserId == u.Id
                select new OrderListViewModel
                {
                    Id = b.BestellingId,
                    //Date = b.Date.ToShortDateString(),
                    Status = b.Status,
                    UserId = u.Id,
                    UserEmail = u.Email
                }
            ).FirstOrDefault();
            
            if (model == null) {
            model =
            (
                from b in context.Bestelling
                select new OrderListViewModel
                {
                    Id = b.BestellingId,
                    Date = b.Date.ToShortDateString(),
                    Status = b.Status
                   
                }
            ).FirstOrDefault();
            }

            return View(model);
        }

        [Route("SetOrderStatus")]
        public IActionResult SetOrderStatus(int? id, string selection)
        {
            if (id == null || selection == null) return NotFound();

            Bestelling order = (from b in context.Bestelling where b.BestellingId == id select b).FirstOrDefault();
            order.Status = selection;
            context.SaveChanges();
            
            return RedirectToAction("Index", "OrderList");
        }

        [Route("OrderContent")]
        public IActionResult OrderContent(int? id)
        {
            if (id == null) return NotFound();

            string uid = (from b in context.Bestelling where b.BestellingId == id select b.UserId).FirstOrDefault();
            OrderContentViewModel model = new OrderContentViewModel
            {
                OrderId = (int)id,
                UserId = uid,
                UserEmail = (from u in context.Users where u.Id == uid select u.Email).FirstOrDefault(),
                Products = 
                (
                    from bi in context.BesteldeItem
                    where bi.BestellingId == id
                    select bi
                ).ToList()
            };

            
            return View(model);
        }
        
        [Route("GetData")]
        public JsonResult GetData(int pageIndex=1)
        {
            // Create the PaginationHelper instance and use it to generate the required page
            PaginationHelper<Bestelling> pagination = new PaginationHelper<Bestelling>(maxPageSize,context.Bestelling);
            PaginationViewModel<Bestelling> orderPage = pagination.GetPage(pageIndex);
            
            // Since the default Productwaarde doesn't contain all of the needed info
            // We will create a new model that we will return
            PaginationViewModel<OrderListViewModel> json =
                OrderListViewModelHelper.ConvertToViewModel(context, orderPage);
            
            return new JsonResult(json);
        }
        
        [Route("GetDataFiltered")]
        public JsonResult GetDataFiltered(string id="", string date="", string status="", string productCount="", string userEmail="", string userId="", int pageIndex=1)
        {
            // Create a PaginationHelper instance. It will be used to generate a page
            PaginationHelper<Bestelling> pagination = new PaginationHelper<Bestelling>(maxPageSize,context.Bestelling);
            
            // Some error checking as JS may give null values!
            if (id == null) { id = ""; }
            if (date == null) { date = ""; }
            if (status == null) { status = ""; }
            if (productCount == null) { productCount = ""; }
            if (userEmail == null) { userEmail = ""; }
            if (userId == null) { userId = ""; }

            // Since the pagination helper doesn't have built-in filtering,
            // we'll have to prepare a custom filtered query and pass it to the helper
            IQueryable<Bestelling> query =
                from b in context.Bestelling
                from u in context.Users
                where u.Id == b.UserId &&
                      b.BestellingId.ToString().Contains(id) &&
                      b.Date.ToShortDateString().Contains(date) &&
                      b.Status.ToUpper().Contains(status.ToUpper()) &&
                      (
                          from bi in context.BesteldeItem
                          where bi.BestellingId == b.BestellingId
                          select bi.Quantity
                      ).Sum().ToString().Contains(productCount) &&
                      b.UserId.ToUpper().Contains(userId.ToUpper()) &&
                      u.NormalizedEmail.Contains(userEmail.ToUpper())
                select b;
                      

            // Generate pages from the custom query
            PaginationViewModel<Bestelling> productPage = pagination.GetPageIQueryable(pageIndex, query);
            
            // Since the default Productwaarde doesn't contain all of the needed info
            // We will create a new model that we will return
            PaginationViewModel<OrderListViewModel> json =
                OrderListViewModelHelper.ConvertToViewModel(context, productPage);
            
            // Encode to JSON and return it
            return new JsonResult(json);
        }
        
    }
}