using System.Collections.Generic;
using System.Linq;
using WebApp1.Models.Database;
using WebApp1.Models.ViewModels;

namespace WebApp1.Models.Helper
{
    public static class UserListViewModelHelper
    {
        public static PaginationViewModel<UserListViewModel> ConvertToViewModel(WebshopContext context, PaginationViewModel<Users> userPage)
        {
            // Initialize a new pagination page and configure the header
            // The Data field will be initialized but remain empty for now
            PaginationViewModel<UserListViewModel> newPage = new PaginationViewModel<UserListViewModel>
            {
                PageNumber = userPage.PageNumber,
                PageSize = userPage.PageSize,
                TotalPages = userPage.TotalPages,
                Data = new List<UserListViewModel>()
            };

            // Begin inserting data into the new page
            // Some of the data is already in the order model
            // Missing ones have to be retrieved from database
            foreach (Users user in userPage.Data)
            {
                UserListViewModel model = new UserListViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Roles = ""
                };

                string[] roles =
                (
                    from u in context.Users
                    from ur in context.UserRoles
                    from r in context.Roles
                    where u.Id == user.Id &&
                          u.Id == ur.UserId &&
                          ur.RoleId == r.Id
                    select r.Name
                ).ToArray();

                for (int i = 0; i < roles.Length; i++)
                {
                    model.Roles += roles[i];
                    if (i != roles.Length - 1)
                    {
                        model.Roles += ", ";
                    }
                }
                          
                newPage.Data.Add(model);
            }
            
            return newPage;
        }
    }
}