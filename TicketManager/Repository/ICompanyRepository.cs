using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManager.Models;

namespace TicketManager.Repository
{
    internal interface ICompanyRepository
    {
        Task<int> Create(string name);
        Task<int> DeleteAsync(int companyID);
        Task<IEnumerable<Company>> GetCompaniesAsync();
        Task<IEnumerable<Company>> GetCompaniesAsync(bool onlyEnabled);
        Task<Company> GetCompanyByIDAsync(int companyID);
        Task<int> Update(string name, int companyID);
    }
}