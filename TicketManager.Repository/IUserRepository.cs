using System.Threading.Tasks;
using TicketManager.Repository.Models;

namespace TicketManager.Repository
{
    public interface IUserRepository
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