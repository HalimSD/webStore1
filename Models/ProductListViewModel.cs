using System.Collections.Generic;
using System.Linq;

namespace WebApp1.Models
{
    public class ProductListViewModel
    {
        // JSON
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
    }

    public class ProductListViewModelHelper
    {
        public List<ProductListViewModel> GetData(WebshopContext context)
        {
            return (
                from pw in context.Productwaarde
                from ps in context.Productsoort
                where pw.ProductsoortId == ps.Id
                select new ProductListViewModel
                {
                    Id = pw.Id,
                    Name = pw.Title,
                    Price = pw.Price,
                    Quantity = pw.Quantity,
                    Category = ps.Naam
                }
            ).ToList();
        }
    }
}