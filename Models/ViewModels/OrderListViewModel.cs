using System;
using System.Collections.Generic;
using System.Linq;
using WebApp1.Models.Database;
using WebApp1.Models.Helper;

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
        public List<OrderDetail> Products { get; set; }
    }
}