﻿using WebApp1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Text.Encodings.Web;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using Remotion.Linq.Clauses;
using WebApp1.Areas.Identity.Pages.Account;
using WebApp1.Models.Database;
using WebApp1.Models.Helper;
using WebApp1.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Controllers
{
    public class UserManagementController : Controller
    {
        private readonly WebshopContext _dbContext;
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _emailSender;
        private readonly int maxPageSize = 25;

        public enum ResultMessage
        {
            passwordReset,
            emailSent,
            passwordIsRequired,
            error
        }

        public UserManagementController(
            WebshopContext dbContext,
            UserManager<Users> userManager,
            RoleManager<IdentityRole> roleManager,
            IEmailSender emailSender)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _emailSender = emailSender;
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //[Authorize(Roles = "Admin")]
        public JsonResult GetUsersData(int pageIndex = 1)
        {
            // Create the PaginationHelper instance and use it to get the first page of productwaarde
            PaginationHelper<Users> pagination = new PaginationHelper<Users>(maxPageSize, _dbContext.Users);
            PaginationViewModel<Users> data = pagination.GetPage(pageIndex);

            PaginationViewModel<UserListViewModel> model = UserListViewModelHelper.ConvertToViewModel(_dbContext, data);

            return new JsonResult(model);
        }
        
        //[Authorize(Roles = "Admin")]
        public JsonResult GetUsersDataFiltered(string id="", string email="", string role="", int pageIndex=1)
        {
            // Create a PaginationHelper instance. It will be used to generate a page
            PaginationHelper<Users> pagination = new PaginationHelper<Users>(maxPageSize,_dbContext.Users);
            
            // Some error checking as JS may give null values!
            if (id == null) { id = ""; }
            if (email == null) { email = ""; }
            if (role == null) { role = ""; }

            // Since the pagination helper doesn't have built-in filtering,
            // we'll have to prepare a custom filtered query
            PaginationViewModel<Users> data = pagination.GetPage(pageIndex);

            PaginationViewModel<UserListViewModel> model = UserListViewModelHelper.ConvertToViewModel(_dbContext, data);
            model.Data =
            (
                from d in model.Data
                where d.Id.ToUpper().Contains(id.ToUpper()) &&
                      d.Email.ToUpper().Contains(email.ToUpper()) &&
                      d.Roles.ToUpper().Contains(role.ToUpper())
                select d
            ).ToList();

            return new JsonResult(model);
        }

        //[Authorize(Roles = "Admin")]
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

        //[Authorize(Roles = "Admin")]
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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> updateInfo()
        {
            Users appUser = await _userManager.GetUserAsync(User);
            UserEdit user = new UserEdit()
            {
                Email = appUser.Email,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                BirthDate = appUser.BirthDate,
                HouseNumber = appUser.HouseNumber,
                Street = appUser.Street,
                PostalCode = appUser.PostalCode,
                City = appUser.City,
                Gender = appUser.Gender,
                TelephoneNumber = appUser.TelephoneNumber
            };
            return View(user);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> updateInfo(UserEdit model)
        {
            Users user = await _userManager.GetUserAsync(User);
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.BirthDate = model.BirthDate;
            user.HouseNumber = model.HouseNumber;
            user.Street = model.Street;
            user.PostalCode = model.PostalCode;
            user.City = model.City;
            user.Email = model.Email;
            user.UserName = model.Email;
            user.Gender = model.Gender;
            user.TelephoneNumber = model.TelephoneNumber;

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

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> updateInfoAdmin(string id)
        {
            Users appUser = await _userManager.FindByIdAsync(id);
            UserEdit user = new UserEdit()
            {
                UserId = appUser.Id,
                Email = appUser.Email,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                BirthDate = appUser.BirthDate,
                HouseNumber = appUser.HouseNumber,
                Street = appUser.Street,
                PostalCode = appUser.PostalCode,
                City = appUser.City,
                Gender = appUser.Gender,
                TelephoneNumber = appUser.TelephoneNumber
            };
            return View(user);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> updateInfoAdmin(UserEdit model)
        {
            Users user = await _userManager.FindByIdAsync(model.UserId);
            user.Id = model.UserId;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.BirthDate = model.BirthDate;
            user.HouseNumber = model.HouseNumber;
            user.Street = model.Street;
            user.PostalCode = model.PostalCode;
            user.City = model.City;
            user.Email = model.Email;
            user.UserName = model.Email;
            user.TelephoneNumber = model.TelephoneNumber;
            user.Gender = model.Gender;


            if (ModelState.IsValid)
            {
                IdentityResult result = await _userManager.UpdateAsync(user);
                await _dbContext.SaveChangesAsync();

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> ResetUserPassword(string id)
        {
            Users appUser = await _userManager.FindByIdAsync(id);
            UserEdit user = new UserEdit()
            {
                UserId = appUser.Id,
                Email = appUser.Email
            };

            return View(user);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> ResetUserPassword(UserEdit model)
        {
            var x = await _userManager.FindByEmailAsync(model.Email);
            if (model.Password != null)
            {
                await _userManager.RemovePasswordAsync(x);
                await _userManager.AddPasswordAsync(x, model.Password);

                ViewBag.resultMsg = ResultMessage.passwordReset;
                return View();
            }
            else if (model.Password == null)
            {
                ViewBag.resultMsg = ResultMessage.passwordIsRequired;
                return View();
            }

            ViewBag.resultMsg = ResultMessage.error;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> sendEmailToUser(UserEdit model)
        {
            var x = await _userManager.FindByEmailAsync(model.Email);
            var code = await _userManager.GeneratePasswordResetTokenAsync(x);
            var callbackUrl =
                Url.Page(
                    "/Account/ResetPassword",
                    pageHandler: null,
                    values: new {area = "Identity", code},
                    protocol: Request.Scheme
                );
            ;
            await _emailSender.SendEmailAsync(
                x.Email,
                "Reset Password",
                $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
            ViewBag.resultMsg = ResultMessage.emailSent;
            return View("ResetUserPassword");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var user = await _userManager.FindByIdAsync(id);
            var x = (from p in _dbContext.Order where p.UserId == id select p).ToList();
            if (user.Id != currentUser.Id)
            {
                foreach (var item in x.ToList())
                {
                    x.Remove(item);
                }

                await _userManager.DeleteAsync(user);
            }
            else
            {
                RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        private async Task<Users> GetUserById(string id) =>
            await _userManager.FindByIdAsync(id);

        private SelectList GetAllRoles() => new SelectList(_roleManager.Roles.OrderBy(r => r.Name));
    }
}