using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Repository.Models;
using TicketManager.ViewModels.User;

namespace TicketManager.Extensions.ViewModel
{
    public static class UserViewModelExtensions
    {
        public static User ToUserModel(this UserAddEditViewModel user)
        {
            return new User
            {
                ID = user.ID,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            };
        }

        public static UserGetViewModel ToViewModel(this User user)
        {
            return new UserGetViewModel
            {
                ID = user.ID,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                CreationDate = user.CreationDate
            };
        }

        public static UserGetAdminViewModel ToAdminViewModel(this User user)
        {
            return new UserGetAdminViewModel
            {
                ID = user.ID,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                CreationDate = user.CreationDate,
                IsAdmin = user.IsAdmin,
                IsEnabled = user.IsEnabled
            };
        }
    }
}
