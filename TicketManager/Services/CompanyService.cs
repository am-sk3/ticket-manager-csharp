using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Entities;
using TicketManager.Models;
using TicketManager.Repository;

namespace TicketManager.Services
{
    internal class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _company;

        public CompanyService(ICompanyRepository company)
        {
            _company = company;
        }

        public async Task<IEnumerable<Company>> GetAllAsync(bool onlyEnabled)
        {
            return await _company.GetAllAsync(onlyEnabled);
        }

        public async Task<Company> GetByIDAsync(int companyID)
        {
            return await _company.GetCompanyByIDAsync(companyID);
        }

        public async Task<int> CreateAsync(string companyName)
        {
            return await _company.CreateAsync(companyName);
        }

        public async Task<int> EditAsync(CompanyClient company, int companyID)
        {
            return await _company.UpdateAsync(company.Name,companyID);
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
