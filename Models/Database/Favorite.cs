namespace WebApp1.Models.Database
{
    public class Favorite
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string UserId { get; set; }
        public string Date { get; set; }
    }
}