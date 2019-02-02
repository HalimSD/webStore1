using System.Collections.Generic;
using System.Linq;
using WebApp1.Models;
using WebApp1.Models.Database;
using WebApp1.Models.Helper;
using WebApp1.Models.ViewModels;

namespace WebApp1.Models
{
    public class ProductListViewModel
    {
        // JSON
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double DiscountedPrice { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
    }
}