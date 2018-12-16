using System.Collections.Generic;

using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;




namespace WebApp1.Models
{



  public class AddCategory
  {
    public class Parent{
      public WebApp1.Models.Productsoort Productsoorts {get; set;}
      public bool selected{get;set;}
    }
    public class Child{
      public WebApp1.Models.Productsoort Productsoorts {get; set;}
      public bool selected{get;set;}
    }
    public IList<Parent> parents{get;set;}
    public IList<Child> children{get;set;}
    public WebApp1.Models.Productsoort productsoort {get; set;}
  }
}