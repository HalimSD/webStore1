using System.Collections.Generic;

namespace WebApp1.Models.Database
{
    public class AttributeType
    {
        public int Id { get; set; }

        //[Required]
        public string Name { get; set; }
        public string Type { get; set; }
        public int CategoryId { get; set; }
        public bool Custom { get; set; }
        public Category Category { get; set; }

        public List<AttributeValue> AttributeValues { get; set; }
    }
}