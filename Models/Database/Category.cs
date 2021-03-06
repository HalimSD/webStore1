using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models.Database
{
    public class Category
    {
        public int Id { get; set; }
        [Required] public string Naam { get; set; }
        public string Image { get; set; }
        public List<AttributeType> AttributeType { get; set; }
        public List<Product> Product { get; set; }
        public List<ParentChild> Children { get; set; }
        public List<ParentChild> Parents { get; set; }
    }
}