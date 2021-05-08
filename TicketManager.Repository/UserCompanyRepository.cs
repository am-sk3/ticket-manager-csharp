using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Repository.Factories;

namespace TicketManager.Repository
{
    public class UserCompanyRepository : IUserCompanyRepository
    {
        private readonly IDatabaseFactory _databaseFactory;

        public UserCompanyRepository(IDatabaseFactory databaseFactory)
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
