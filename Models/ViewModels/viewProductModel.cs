using System.Collections.Generic;

namespace WebApp1.Models
{
    public class ViewProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string DiscountedPrice { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public List<string[]> CategoryPath { get; set; }

    }
    
    public class ViewProductAttributes
    {
        public int AttributeNameId { get; set; }
        public string AttributeName { get; set; }
        public int AttributeValueId { get; set; }
        public string AttributeValue { get; set; }
        public string Type { get; set; }
    }
}