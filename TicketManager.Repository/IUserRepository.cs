using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManager.Repository.Models;

namespace TicketManager.Repository
{
    public interface IUserRepository
    {
        Task<int> ChangePassword(string password, int userID);
        Task<int> Create(User user);
        Task<int> Delete(int userID);
        Task<IEnumerable<User>> GetAll();
        Task<IEnumerable<User>> GetAll(bool onlyEnabled);
        Task<User> GetByEmail(string email);
        Task<User> GetByID(int userID);
        Task<int> Update(User user);
    }
}