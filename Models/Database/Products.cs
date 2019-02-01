using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models.Database
{
    public class Product
    {
        public int Id { get; set; }

        //[StringLength(60, MinimumLength = 3)]
        [Required] public string Title { get; set; }

        //[Range(1, 1000000)]
        //[DataType(DataType.Currency)]
        //[Column(TypeName = "double(18, 2)")]
        [Required] public double Price { get; set; }

        //[Range(1, 1000000)]
        //[DataType(DataType.Currency)]
        //[Column(TypeName = "double(18, 2)")]
        //[Required]
        public double DiscountedPrice { get; set; }

        //[Required]
        public string Image { get; set; }

        public int Quantity { get; set; }

        //[StringLength(10000, MinimumLength = 3)]
        [Required] public string Description { get; set; }
        public int ProductsoortId { get; set; }
        public Category Category { get; set; }
        public List<AttributeValue> AttributeValue { get; set; }
        public List<AttributeType> AttributeType { get; set; }
    }


}


//this is the typed representation of an actor in our project