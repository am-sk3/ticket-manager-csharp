using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Repository.Factories;
using TicketManager.Repository.Models;

namespace TicketManager.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDatabaseFactory _databaseFactory;

        public UserRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public async Task GetByID(int userID)
        {
            throw new NotImplementedException();
        }

        public async Task GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task GetAll(bool onlyEnabled)
        {
            throw new NotImplementedException();
        }

        public async Task Create(User user)
        {
            throw new NotImplementedException();
        }

        public async Task Update(User user)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int userID)
        {
            throw new NotImplementedException();
        }

        public async Task ChangePassword(string password, int userID)
        {
            throw new NotImplementedException();
        }

        public async Task GetByEmail(string email)
        {
            throw new NotImplementedException();
        }



    }
}
