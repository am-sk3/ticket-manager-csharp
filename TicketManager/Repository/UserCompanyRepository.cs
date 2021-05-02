using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Factories;

namespace TicketManager.Repository
{
    public class UserCompanyRepository
    {
        private readonly IDatabaseFactory _databaseFactory;

        public UserCompanyRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        internal async Task<int> AddUserToCompany(int userID,int companyID)
        {
            throw new NotImplementedException();
        }

        internal async Task<int> RemoveUserFromCompany(int userID,int companyID)
        {
            throw new NotImplementedException();
        }

        internal async Task<int> GetAllUsersFromCompany(int company)
        {
            throw new NotImplementedException();
        }

        internal async Task GetUserByEmail(string userEmail)
        {
            throw new NotImplementedException();
        }

        internal async Task GetByUserID(int userID)
        {
            throw new NotImplementedException();
        }


    }
}
