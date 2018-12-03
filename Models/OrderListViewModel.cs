using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApp1.Models
{
    public class OrderListViewModel
    {
        // JSON
        public int Id { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
        public int ProductCount { get; set; }
        public string UserEmail { get; set; }
        public string UserId { get; set; }
    }

    public class OrderContentViewModel
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public List<BesteldeItem> Products { get; set; }
    }

    /// <summary>
    /// Helper class that is associated with the OrderListViewModel class.
    /// This helper class is used to convert a Pagination Bestelling page model
    /// to a pagination page that contains OrderListViewModel class instead of Bestelling class 
    /// </summary>
    public static class OrderListViewModelHelper
    {
        public static PaginationViewModel<OrderListViewModel> ConvertToViewModel(WebshopContext context, PaginationViewModel<Bestelling> orderPage)
        {
            // Initialize a new pagination page and configure the header
            // The Data field will be initialized but remain empty for now
            PaginationViewModel<OrderListViewModel> newPage = new PaginationViewModel<OrderListViewModel>
            {
                PageNumber = orderPage.PageNumber,
                PageSize = orderPage.PageSize,
                TotalPages = orderPage.TotalPages,
                Data = new List<OrderListViewModel>()
            };
            
            // Begin inserting data into the new page
            // Some of the data is already in the order model
            // Missing ones have to be retrieved from database
            foreach (Bestelling order in orderPage.Data)
            {
                OrderListViewModel model = new OrderListViewModel
                {
                    Id = order.BestellingId,
                    Date = order.Date.ToShortDateString(),
                    Status = order.Status,
                    ProductCount = 
                        (
                            from bi in context.BesteldeItem
                            where bi.BestellingId == order.BestellingId
                            select bi.Quantity
                        ).Sum(),
                    UserEmail = (from u in context.Users where u.Id == order.UserId select u.Email).FirstOrDefault(),
                    UserId = order.UserId
                };
                newPage.Data.Add(model);
            }

            return newPage;
        }
    }
}