using System.Collections.Generic;
using WebApp1.Models;
using WebApp1.Models.Database;

namespace WebApp1.Models
{
    public class EditproductsoortModel
    {
        public IList<Category> productsoorts {get;set;} 
        public string productsoort {get;set;}
    }
}