namespace WebApp1.Models.Database
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public virtual Order Order { get; set; }

    }
}