using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace WebApp1.Models
{
    public class Users : IdentityUser
    {
        public ICollection<Bestelling> Bestelling { get; set; }

        // public string FirstName {get;set;}
        // public string LastName {get;set;}

    }
    public class BesteldeItem
    {
        public int BesteldeItemId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int BestellingId { get; set; }
        public virtual Bestelling Bestelling { get; set; }
    }

    public class Bestelling
    {
        public int BestellingId { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
        public ICollection<BesteldeItem> BesteldeItem { get; set; }
        public string UserId { get; set; }
        public virtual Users User { get; set; }

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
                await _roleManager.CreateAsync(new IdentityRole { Name = "Member" });
            }
            if ((await _roleManager.FindByNameAsync("Admin")) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
            }
        }
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
        [Required]
        public string Email { get; set; }
    }
}