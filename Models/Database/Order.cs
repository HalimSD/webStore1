using System;
using System.Collections.Generic;

namespace WebApp1.Models.Database
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string email {get; set;}
        public string Status { get; set; }
        public double ShippingFee { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public string UserId { get; set; }
        public virtual Users User { get; set; }

    }
}