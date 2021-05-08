using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManager.Repository.Models;

namespace TicketManager.Repository
{
    public interface ICompanyRepository
    {
        Task<int> CreateAsync(string name);
        Task<int> DeleteAsync(int companyID);
        Task<IEnumerable<Company>> GetAllAsync();
        Task<IEnumerable<Company>> GetAllAsync(bool onlyEnabled);
        Task<Company> GetCompanyByIDAsync(int companyID);
        Task<int> UpdateAsync(Company company);
    }
}