using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Factories;

namespace TicketManager.Repository
{
    internal class UserCompanyRepository : IUserCompanyRepository
    {
        private readonly IDatabaseFactory _databaseFactory;

        internal UserCompanyRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public async Task<int> AddUserToCompany(int userID, int companyID)
        {
            throw new NotImplementedException();
        }

        public async Task<int> RemoveUserFromCompany(int userID, int companyID)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetAllUsersFromCompany(int company)
        {
            throw new NotImplementedException();
        }

        public async Task GetUserByEmail(string userEmail)
        {
            throw new NotImplementedException();
        }

        public async Task GetByUserID(int userID)
        {
            throw new NotImplementedException();
        }


    }
}
