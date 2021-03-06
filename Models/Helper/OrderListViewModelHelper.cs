using System.Collections.Generic;
using System.Linq;
using WebApp1.Models.Database;

namespace WebApp1.Models.Helper
{
    /// <summary>
    /// Helper class that is associated with the OrderListViewModel class.
    /// This helper class is used to convert a Pagination Bestelling page model
    /// to a pagination page that contains OrderListViewModel class instead of Bestelling class 
    /// </summary>
    public static class OrderListViewModelHelper
    {
        public static PaginationViewModel<OrderListViewModel> ConvertToViewModel(WebshopContext context,
            PaginationViewModel<Order> orderPage)
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
            foreach (Order order in orderPage.Data)
            {
                OrderListViewModel model = new OrderListViewModel
                {
                    Id = order.Id,
                    Date = order.Date.ToShortDateString(),
                    Status = order.Status,
                    ProductCount =
                    (
                        from bi in context.OrderDetail
                        where bi.OrderId == order.Id
                        select bi.Quantity
                    ).Sum(),
                    UserEmail = order.email,
                    UserId = order.UserId
                };
                newPage.Data.Add(model);
            }

            return newPage;
        }
    }
}