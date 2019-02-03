using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp1.Models;
using WebApp1.Models.Database;

namespace WebApp1.CreateproductModel
{
    public class CreateproductModel
    {
        public class Atribuutsoortmetwaardes
        {
            public AttributeType extraAtribute { get; set; }
            public AttributeValue extraAtributewaarde { get; set; }
        }
        // public class AlreadyCustomAtributes{
        //     public WebApp1.Models.Attribuutsoort customAtribute {get; set;}
        //      public WebApp1.Models.Attribuutwaarde cattribuutwaarde {get; set;}
        //     public bool selected{get;set;}
        // }

        public class AllCustomAtt
        {
            public Category productSoort { get; set; }
            public List<AtwthBool> customAtributes { get; set; }
            public List<AttributeValue> cattribuutwaarde { get; set; }
        }

        public class AtwthBool
        {
            public AttributeType customAtribute { get; set; }
            public bool selected { get; set; }
        }


        public IList<AllCustomAtt> AcustomAtributesall { get; set; }
        //  public IList<AlreadyCustomAtributes> AcustomAtributesproductsoort {get;set;}

        public IList<AttributeType> Attribuutsoorts { get; set; }
        public IList<Atribuutsoortmetwaardes> newcustom { get; set; }


        public Product Product { get; set; }
        //public IList<Attribuutwaarde> Attribuutwaardes { get; set; }


        public int GetAttribuutsoortsA()
        {
            var AttribuutsoortsA = from a in Attribuutsoorts select a.CategoryId;
            return AttribuutsoortsA.ToArray()[0];
        }
    }
}