using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp1.Models;

namespace WebApp1.CreateproductModel
{
    public class CreateproductModel
    {
        public class Atribuutsoortmetwaardes{
              public WebApp1.Models.Attribuutsoort extraAtribute {get; set;}
              public WebApp1.Models.Attribuutwaarde extraAtributewaarde {get; set;}
        }
        public class AlreadyCustomAtributes{
            public WebApp1.Models.Attribuutsoort customAtribute {get; set;}
             public WebApp1.Models.Attribuutwaarde cattribuutwaarde {get; set;}
            public bool selected{get;set;}
        }

         public IList<AlreadyCustomAtributes> AcustomAtributesall {get;set;}
         public IList<AlreadyCustomAtributes> AcustomAtributesproductsoort {get;set;}
        
        public IList<WebApp1.Models.Attribuutsoort> Attribuutsoorts {get; set;}
        public IList<Atribuutsoortmetwaardes> newcustom{get;set;}
        

        public Productwaarde productwaarde {get;set;}
        //public IList<Attribuutwaarde> Attribuutwaardes { get; set; }
        

         public int GetAttribuutsoortsA() {
            var AttribuutsoortsA = from a in Attribuutsoorts select a.ProductsoortId;
            return AttribuutsoortsA.ToArray()[0];
         }
    }
}