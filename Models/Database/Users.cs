using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
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
                await _roleManager.CreateAsync(new IdentityRole { Name = "Member" });
            }

            if ((await _roleManager.FindByNameAsync("Admin")) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
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
        [Required(ErrorMessage = "Email invullen is verplicht")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Voornaam invullen is verplicht")]
        [StringLength(30, ErrorMessage = "De voornaam moet minimaal {2} en maximaal {1} characters zijn.", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Achternaam invullen is verplicht")]
        [StringLength(30, ErrorMessage = " De Achternaam moet minimaal {2} en maximaal {1} characters zijn.", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Geboortedatum invullen is verplicht")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Straat naam invullen is verplicht")]
        [StringLength(30, ErrorMessage = "De straat naam moet minimaal {2} en maximaal {1} characters zijn.", MinimumLength = 2)]
        public string Street { get; set; }

        [Required(ErrorMessage = "Huisnummer invullen is verplicht")]
        [StringLength(3, ErrorMessage = "Het huisnummer moet minimaal {2} en maximaal {1} characters zijn.", MinimumLength = 1)]
        public string HouseNumber { get; set; }

        [Required(ErrorMessage = "Postcode invullen is verplicht")]
        [StringLength(6, ErrorMessage = "de postcode moet minimaal {2} en maximaal {1} characters zijn.", MinimumLength = 4)]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Telefoonnummer invullen is verplicht")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "Moet een nummer zijn.")]
        public int TelephoneNumber { get; set; }

        [Required(ErrorMessage = "Stadsnaam invullen is verplicht")]
        [StringLength(30, ErrorMessage = "De stadsnaam moet minimaal {2} en maximaal {1} characters zijn.", MinimumLength = 2)]
        public string City { get; set; }

        [Required(ErrorMessage = "Land naam invullen is verplicht")]
        [StringLength(20, ErrorMessage = "De landsnaam moet minimaal {2} en maximaal {1} characters zijn.", MinimumLength = 2)]
        public string Country { get; set; }

    }
    public class AddressValidator : AbstractValidator<SubscribeModel>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Email)
            .Cascade(CascadeMode.Continue)
            .NotEmpty().WithMessage("{PropertyName} invullen is verplicht")
            .EmailAddress().WithMessage("Vul een geldige {PropertyName} in.");

            RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Vul een geldige voornaam in.");

            RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Vul een geldige achternaam in.");

            RuleFor(x => x.BirthDate)
            .Must(validAge).WithMessage("ongeldig geboortedatum");

            RuleFor(x => x.Street)
            .NotEmpty().WithMessage("Vul een geldige straat naam in.");

            RuleFor(x => x.HouseNumber)
            .NotEmpty().WithMessage("Vul een geldige huisnummer in.");

            RuleFor(x => x.PostalCode)
            .NotEmpty().WithMessage("Vul een geldige post code in.");

            RuleFor(x => x.TelephoneNumber)
            .NotEmpty().WithMessage("Vul een geldige telefoonnummer in.");

            RuleFor(x => x.City)
            .NotEmpty().WithMessage("Vul een geldige stad naam in.");

            RuleFor(x => x.Country)
            .NotEmpty().WithMessage("Vul een geldige land naam in.");
        }
        protected bool validAge(DateTime date)
        {
            int currentYear = DateTime.Now.Year;
            int dobYear = date.Year;
            if (dobYear <= (currentYear - 18) && dobYear > (currentYear - 120))
            {
                return true;
            }
            return false;
        }
    }
}