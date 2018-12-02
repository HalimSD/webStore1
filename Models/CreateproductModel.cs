using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp1.Products;

namespace WebApp1.CreateproductModel
{
    public class CreateproductModel
    {
        
        public IEnumerable<WebApp1.Products.Attribuutsoort> Attribuutsoorts {get; set;}

        
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public double DiscountedPrice { get; set; }
        public int ProductsoortId{ get; set; }
        public Productsoort productsoort { get; set; }
        public List<Attribuutwaarde> Attribuutwaarde { get; set; }

         public int GetAttribuutsoortsA() {
            var AttribuutsoortsA = from a in Attribuutsoorts select a.ProductsoortId;
            return AttribuutsoortsA.ToArray()[0];
         }
    }
}