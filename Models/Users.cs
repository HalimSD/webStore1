using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace WebApp1.Models
{
    public class Users : IdentityUser{
         // public string FirstName {get;set;}
        // public string LastName {get;set;}

    }
    public class Roles : IdentityRole{
        private readonly RoleManager <IdentityRole> _roleManager;
        public Roles ( RoleManager<IdentityRole> roleManager){
            _roleManager = roleManager;
        }

        public async void Seed(){
            if ((await _roleManager.FindByNameAsync("Member")) == null){
                await _roleManager.CreateAsync(new IdentityRole{Name = "Member"});
            }
            if ((await _roleManager.FindByNameAsync("Admin")) == null){
                await _roleManager.CreateAsync(new IdentityRole{Name = "Admin"});
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
}