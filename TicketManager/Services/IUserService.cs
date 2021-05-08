using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManager.ViewModels.User;

namespace TicketManager.Services
{
    public interface IUserService
    {
        Task<int> ChangePasswordAsync(string password, int userID);
        Task<int> CreateAsync(UserAddEditViewModel user);
        Task<int> EditAsync(UserAddEditViewModel user, int userID);
        Task<IEnumerable<UserGetViewModel>> GetAllAsync();
        Task<UserGetViewModel> GetByIdAsync(int userID);
        Task<int> RemoveAsync(int userID);
    }
}