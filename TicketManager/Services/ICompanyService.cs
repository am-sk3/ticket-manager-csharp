using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManager.Entities;
using TicketManager.Models;

namespace TicketManager.Services
{
    public interface ICompanyService
    {
        Task AddUserAsync(int companyID, int userID);
        Task<int> CreateAsync(string companyName);
        Task<int> EditAsync(CompanyClient company, int companyID);
        Task<IEnumerable<Company>> GetAllAsync(bool onlyEnabled);
        Task<Company> GetByIDAsync(int companyID);
        Task<int> RemoveAsync(int companyID);
        Task RemoveUserAsync(int companyID, int userID);
    }
}