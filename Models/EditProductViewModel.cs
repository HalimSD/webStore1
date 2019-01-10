using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using WebApp1.Controllers;
using WebApp1.Controllers.Admin;

namespace WebApp1.Models
{
    public class EditProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Titel moet een waarde bevatten!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "De prijs moet een getal zijn zonder letters!")]
        [RegularExpression(@"^[0-9]*,*.*$", ErrorMessage = "Waarde moet een positief getal zijn!")]
        public string Price { get; set; }

        [Required(ErrorMessage = "De kortingsprijs moet een getal zijn zonder letters!")]
        [RegularExpression(@"^[0-9]*,*.*$", ErrorMessage = "Waarde moet een getal zijn!")]
        public string DiscountedPrice { get; set; }

        public string Image { get; set; }

        [Required(ErrorMessage = "Waarde moet een positief getal zijn zonder decimalen!")]
        [Range(0, int.MaxValue, ErrorMessage = "Waarde moet een positief getal zijn zonder decimalen!")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Waarde moet een positief getal zijn zonder decimalen!")]
        public int Quantity { get; set; }

        public string Description { get; set; }
        public int ProductsoortId { get; set; }
        public EditProductController.ResultMsg ResultMsg { get; set; } = EditProductController.ResultMsg.None;
        public List<NumberAttributeModel> NumberAttributes { get; set; } = new List<NumberAttributeModel>();
        public List<StringAttributeModel> StringAttributes { get; set; } = new List<StringAttributeModel>();
        public bool UseDiscount { get; set; }
        
    }

    public class NumberAttributeModel
    {
        public int AttributeNameId { get; set; }
        public string AttributeName { get; set; }
        public int AttributeValueId { get; set; }

        [Required(ErrorMessage = "De waarde moet een getal zijn zonder letters!")]
        [Range(double.MinValue, double.MaxValue, ErrorMessage = "De waarde moet een getal zijn zonder letters!")]
        [RegularExpression(@"^[0-9]*,*.*$", ErrorMessage = "Waarde moet een getal zijn!")]
        public string AttributeValue { get; set; }

        public string Type { get; } = "number";
    };

    public class StringAttributeModel
    {
        public int AttributeNameId { get; set; }
        public string AttributeName { get; set; }
        public int AttributeValueId { get; set; }

        [Required(ErrorMessage = "Deze veld is verplicht!")]
        public string AttributeValue { get; set; }

        public string Type { get; } = "string";
    };
}