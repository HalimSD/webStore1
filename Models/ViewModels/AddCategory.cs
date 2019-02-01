using System.Collections.Generic;

using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models.Database;


namespace WebApp1.Models
{



  public class AddCategory
  {
    public class Parent{
      public Category Categories {get; set;}
      public bool selected{get;set;}
    }
    public class Child{
      public Category Categories {get; set;}
      public bool selected{get;set;}
    }
    public IList<Parent> parents{get;set;}
    public IList<Child> children{get;set;}
    public Category Category {get; set;}
  }
}