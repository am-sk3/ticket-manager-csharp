using System.Threading.Tasks;
using TicketManager.Models;

namespace TicketManager.Repository
{
    internal interface IUserRepository
    {
        Task ChangePassword(string password, int userID);
        Task Create(User user);
        Task Delete(int userID);
        Task GetAll();
        Task GetAll(bool onlyEnabled);
        Task GetByEmail(string email);
        Task GetByID(int userID);
        Task Update(User user);
    }
}