using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Repository;
using TicketManager.Repository.Models;
using TicketManager.ViewModels.User;
using TicketManager.Extensions.ViewModel;

namespace TicketManager.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _user;

        public UserService(IUserRepository user)
        {
            _user = user;
        }

        public async Task<IEnumerable<UserGetViewModel>> GetAllAsync()
        {
            var result = await _user.GetAll();
            return result.Select(x => x.ToViewModel());
        }

        public async Task<UserGetViewModel> GetByIdAsync(int userID)
        {
            var result = await _user.GetByID(userID);
            return result.ToViewModel();
        }

        public async Task<int> CreateAsync(UserAddEditViewModel user)
        {
            var request = user.ToUserModel();

            return await _user.Create(request);
        }

        public async Task<int> EditAsync(UserAddEditViewModel user, int userID)
        {
            var request = user.ToUserModel();
            request.ID = userID;

            return await _user.Update(request);
        }

        public async Task<int> RemoveAsync(int userID)
        {
            return await _user.Delete(userID);
        }

        public async Task<int> ChangePasswordAsync(string password, int userID)
        {
            return await _user.ChangePassword(password, userID);
        }


    }
}
