using System.Collections.Generic;

using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp1.products
{

public class Products
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
    
    public List<Extra_Atributes> Extra_Atributes { get; set; }
    }
   public class Item
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Productwaarde Product { get; set; }

    }

public class Extra_Atributes
  {
    public int Id { get; set; }
    public string Atribute { get; set; }
    public int ProductsId { get; set; }
    public Products products { get; set; }
  }





public class Productsoort
  {
    public int Id { get; set; }
    public string Naam { get; set; }
    public List<Attribuutsoort> Attribuutsoort  { get; set; }
    public List<Productwaarde> Productwaarde  { get; set; }
    
  }
  public class Attribuutsoort
  {
    public int Id { get; set; }
    public string Attrbuut { get; set; }
    public string Type { get; set; }
    public int ProductsoortId{ get; set; }
    public Productsoort productsoort { get; set; }
    public List<Attribuutwaarde> Attribuutwaarde { get; set; }
  }

  public class Productwaarde
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
    public string Image { get; set; }
    public int Quantity { get; set; }
    public string Description { get; set; }
    public int ProductsoortId{ get; set; }
    public Productsoort productsoort { get; set; }
    public List<Attribuutwaarde> Attribuutwaarde { get; set; }
  }

  public class Attribuutwaarde
  {
    public int Id { get; set; }
    public string Waarde { get; set; }
    public int ProductwaardeId{ get; set; }
    public int AttribuutsoortId{get; set;}
    public Attribuutsoort attribuutsoort { get; set; }
    public Productwaarde productwaarde { get; set; }

  }

 
  //this is the typed representation of an actor in our project
  
}