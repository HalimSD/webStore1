using WebApp1.Models.Database;

namespace WebApp1.Models.ViewModels
{
    public class Item

    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public Product Product { get; set; }
    }
}