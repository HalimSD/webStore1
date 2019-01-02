using WebApp1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ContosoRTM.Controllers
{
    public class UserManagementController : Controller
    {
        private readonly WebshopContext _dbContext;
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserManagementController(
            WebshopContext dbContext,
            UserManager<Users> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {

            var vm = new UserManagementIndex
            {
                Users = _dbContext.Users.OrderBy(u => u.Email).ToList()
                // .Include(u => u.Roles).ToList()
            };



            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> AddRole(string id)
        {
            var user = await GetUserById(id);
            var vm = new UserManagementAddRole
            {
                Roles = GetAllRoles(),
                UserId = id,
                Email = user.Email
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(UserManagementAddRole rvm)
        {
            var user = await GetUserById(rvm.UserId);
            if (ModelState.IsValid)
            {
                var result = await _userManager.AddToRoleAsync(user, rvm.NewRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }
            rvm.Email = user.Email;
            rvm.Roles = GetAllRoles();
            return View(rvm);

        }
        [HttpGet]
        public async Task<IActionResult> updateInfo(string id)
        {
            Users appUser = new Users();
            appUser = await GetUserById(id);
            UserEdit user = new UserEdit()
            {
                UserId = id,
                Email = appUser.Email,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                BirthDate = appUser.BirthDate,
                HouseNumber = appUser.HouseNumber,
                Street = appUser.Street,
                PostalCode = appUser.PostalCode,
                City = appUser.City
            };
            // Users vm =GetUserById(id).Result;
            //  _dbContext.Users.Find(id);
            // var vm = _userManager.FindByIdAsync(id).Result;

            return View(user);
        }


        [HttpPost]
        public async Task<IActionResult> updateInfo(UserEdit model)
        {

            //  var store = new UserStore<Users>(_dbContext);
            //  var manager =  _userManager. UserManager<Users>(store);
            // var store = new UserStore<Users>(_dbContext);
            // var currentUserId = _userManager.Users;
            var user = await GetUserById(model.UserId);

            if (ModelState.IsValid)
            {
                IdentityResult result = await _userManager.UpdateAsync(user);
                    await _dbContext.SaveChangesAsync();

                if (result.Succeeded)
                {
                    
                    return View(model);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }
            // var result = await vm;
    

            // var user = await GetUserById(rvm.UserId);

            return RedirectToAction("Index");
        }

        private async Task<Users> GetUserById(string id) =>
            await _userManager.FindByIdAsync(id);

        private SelectList GetAllRoles() => new SelectList(_roleManager.Roles.OrderBy(r => r.Name));

    }


}
