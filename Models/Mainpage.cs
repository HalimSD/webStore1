using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Mainpage
{
    public class Mainpage
    {
        private int _pageindex;

        public string currentCategoryName { get; set; }
        public int pagesize { get; set; }
        public int pageindex
         
        
        
        { 
            get {return _pageindex;} 
            set {
                    _pageindex = value;
                    if (_pageindex < 1){ _pageindex = 1;}
                    else if (_pageindex>getnumberofpages()){_pageindex = getnumberofpages();}

                } 
        }

        public class Prodctding{
            public WebApp1.Models.Productsoort Productsoorts {get; set;}
            public List<WebApp1.Models.Attribuutsoort> Attribuutsoorts {get; set;}

            public bool selected{get;set;}

        }

        public class Productsoortfilter{
            public WebApp1.Models.Productsoort Productsoorts {get; set;}
            public bool selected{get;set;}

        }
        
        
        public IList<Prodctding> prodctding{get;set;}

        public IList<Productsoortfilter> productsoortfilters{get;set;}
        public IEnumerable<WebApp1.Models.Productwaarde> productwaardes {get; set;}

        public IEnumerable<WebApp1.Models.Productsoort> productsoorten {get; set;}


        public int getnumberofpages(){
           int rest = productwaardes.Count()%pagesize;
           int div = productwaardes.Count()/pagesize;
           if (rest!= 0 ){
               div += 1;
           }
           return div;
        }

         public IEnumerable<WebApp1.Models.Productwaarde> Page() {
             return productwaardes.Skip((pageindex - 1) *pagesize).Take(pagesize);
         }

         public IEnumerable<string> Getproductsoortnamen() {
            var productsoortnamen = from productsoortnaam in productsoorten select productsoortnaam.Naam;
            return productsoortnamen.ToList();
         }


         

    }
}