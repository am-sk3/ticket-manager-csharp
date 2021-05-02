using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManager.Entities;

namespace TicketManager.Repository
{
    internal interface ICompanyRepository
    {
        Task<int> CreateAsync(string name);
        Task<int> DeleteAsync(int companyID);
        Task<IEnumerable<Company>> GetAllAsync();
        Task<IEnumerable<Company>> GetAllAsync(bool onlyEnabled);
        Task<Company> GetCompanyByIDAsync(int companyID);
        Task<int> UpdateAsync(string name, int companyID);
    }
}