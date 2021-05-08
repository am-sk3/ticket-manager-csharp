using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManager.Repository.Models;
using TicketManager.ViewModels.Company;

namespace TicketManager.Services
{
    public interface ICompanyService
    {
        Task AddUserAsync(int companyID, int userID);
        Task<int> CreateAsync(CompanyAddEditViewModel company);
        Task<int> EditAsync(CompanyAddEditViewModel company, int companyID);
        Task<IEnumerable<CompanyGetViewModel>> GetAllAsync(bool onlyEnabled);
        Task<CompanyGetViewModel> GetByIDAsync(int companyID);
        Task<int> RemoveAsync(int companyID);
        Task RemoveUserAsync(int companyID, int userID);
    }
}