namespace WebApp1.Models.Database
{
    public class AttributeValue
    {
        public int Id { get; set; }

        //[Required]
        public string Waarde { get; set; }
        public int ProductwaardeId { get; set; }
        public int AttribuutsoortId { get; set; }
        public AttributeType AttributeType { get; set; }
        public Product Product { get; set; }
    }
}