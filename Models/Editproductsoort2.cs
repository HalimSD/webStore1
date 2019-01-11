using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApp1.Models;

namespace WebApp1.Models
{
    public class EditproductsoortModel2
    {
        
        public string oldproductsoort{get;set;}
        [Required]
        public string newproductsoort{get;set;}
        public IList<Attribuutsoort> atributes{get;set;}
    }
}