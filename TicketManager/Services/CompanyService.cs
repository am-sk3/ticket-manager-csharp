using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Extensions.ViewModel;
using TicketManager.Repository;
using TicketManager.Repository.Models;
using TicketManager.ViewModels.Company;

namespace TicketManager.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _company;

        public CompanyService(ICompanyRepository company)
        {
            _company = company;
        }

        public async Task<IEnumerable<CompanyGetViewModel>> GetAllAsync(bool onlyEnabled)
        {
            var result = await _company.GetAllAsync(onlyEnabled);

            return result.Select(x => x.ToGetViewModel());
        }

        public async Task<CompanyGetViewModel> GetByIDAsync(int companyID)
        {
            var result = await _company.GetCompanyByIDAsync(companyID);
            return result.ToGetViewModel();
        }

        public async Task<int> CreateAsync(CompanyAddEditViewModel company)
        {
            return await _company.CreateAsync(company.Name);
        }

        public async Task<int> EditAsync(CompanyAddEditViewModel company, int companyID)
        {
            company.ID = companyID;
            return await _company.UpdateAsync(company.ToCompanyModel());
        }

        public async Task<int> RemoveAsync(int companyID)
        {
            return await _company.DeleteAsync(companyID);
        }

        public async Task AddUserAsync(int companyID, int userID)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveUserAsync(int companyID, int userID)
        {
            throw new NotImplementedException();
        }
    }
}
