using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Entities;
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

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _company.GetAllAsync();
        }

        public async Task GetByIDAsync(int companyID)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(Company company)
        {
            throw new NotImplementedException();
        }

        public async Task EditAsync(Company company)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(int companyID)
        {
            throw new NotImplementedException();
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
