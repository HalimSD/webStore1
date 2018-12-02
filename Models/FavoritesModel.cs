using WebApp1.Products;

namespace WebApp1.Models
{
    public class FavoritesModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Productwaarde Product { get; set; }
        public string UserId { get; set; }
        public string Date { get; set; }
    }

    public class FavoritesViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
        public string Date { get; set; }
    }
}