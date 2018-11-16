namespace WebApp1.Models
{
    public class ViewProductModel
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
    }
    
    public class ViewProductAttributes
    {
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
    }
}