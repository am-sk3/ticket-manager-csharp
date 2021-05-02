using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManager.Entities;

namespace TicketManager.Services
{
    public interface ICompanyService
    {
        Task AddUserAsync(int companyID, int userID);
        Task CreateAsync(Company company);
        Task EditAsync(Company company);
        Task<IEnumerable<Company>> GetAllAsync();
        Task GetByIDAsync(int companyID);
        Task RemoveAsync(int companyID);
        Task RemoveUserAsync(int companyID, int userID);
    }
}