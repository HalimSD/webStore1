using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using WebApp1.Models.Database;

namespace WebApp1.Models
{
    public class Users : IdentityUser

    {
        public Users() : base()
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string Gender { get; set; }
        public int TelephoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public ICollection<Order> Bestelling { get; set; }

        // public string LastName {get;set;}
    }


    public class Roles : IdentityRole
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public Roles(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async void Seed()
        {
            if ((await _roleManager.FindByNameAsync("Member")) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole {Name = "Member"});
            }

            if ((await _roleManager.FindByNameAsync("Admin")) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole {Name = "Admin"});
            }
        }
    }

    public class UserEdit
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public int TelephoneNumber { get; set; }
    }

    public class UserManagementAddRole
    {
        public string UserId { get; set; }
        public string NewRole { get; set; }
        public SelectList Roles { get; set; }
        public string Email { get; set; }
    }

    public class UserManagementIndex
    {
        public List<Users> Users { get; set; }
    }

    public class SubscribeModel
    {
        [Required] public string Email { get; set; }
    }
}