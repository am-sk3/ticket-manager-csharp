using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Factories;
using TicketManager.Models;

namespace TicketManager.Repository
{
    public class UserRepository
    {
        private readonly IDatabaseFactory _databaseFactory;

        public UserRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        internal async Task GetByID(int userID)
        {
            throw new NotImplementedException();
        }

        internal async Task GetAll()
        {
            throw new NotImplementedException();
        }
        
        internal async Task GetAll(bool onlyEnabled)
        {
            throw new NotImplementedException();
        }

        internal async Task Create(User user)
        {
            throw new NotImplementedException();
        }

        internal async Task Update(User user)
        {
            throw new NotImplementedException();
        }

        internal async Task Delete(int userID)
        {
            throw new NotImplementedException();
        }

        internal async Task ChangePassword(string password, int userID)
        {
            throw new NotImplementedException();
        }

        internal async Task GetByEmail(string email)
        {
            throw new NotImplementedException();
        }



    }
}
