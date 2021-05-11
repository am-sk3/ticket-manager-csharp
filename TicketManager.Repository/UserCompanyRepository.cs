using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Repository.Factories;
using TicketManager.Repository.Models;

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
            using var conn = await DbConnectionAsync();

            string query = 
                @"INSERT INTO Users_Companies(user_id,company_id)
                    VALUES(@userID,@companyID)";

            return await conn.ExecuteAsync(query, new { userID, companyID });
        }

        public async Task<int> RemoveUserFromCompany(int userID, int companyID)
        {
            using var conn = await DbConnectionAsync();

            string query = "DELETE FROM Users_Companies WHERE user_id = @userID AND company_id = @companyID";

            return await conn.ExecuteAsync(query, new { userID, companyID });
        }

        public async Task<IEnumerable<UserCompany>> GetAllUsersFromCompany(int companyID)
        {
            using var conn = await DbConnectionAsync();

            string query =
                @"SELECT 
                        user_id AS ID
                        ,Users.Name
                    FROM 
                        Users_Companies 
                    INNER JOIN Users ON Users.Id = Users_Companies.user_id
                    WHERE 
                        Users_Companies.company_id = @companyID";

            return await conn.QueryAsync<UserCompany>(query, new { companyID });
        }

        public async Task<IEnumerable<CompanyUser>> GetAllCompaniesFromUserID(int userID)
        {
            using var conn = await DbConnectionAsync();

            string query =
                @"SELECT 
                        company_id  AS ID
                        ,Companies.Name
                    FROM 
                        Users_Companies 
                    INNER JOIN Companies ON Companies.Id = Users_Companies.company_id
                    WHERE 
                        Users_Companies.user_id = @userID";

            return await conn.QueryAsync<CompanyUser>(query, new { userID });
        }

        private async Task<IDbConnection> DbConnectionAsync()
        {
            return await _databaseFactory.GetConnectionAsync();
        }

        private IDbConnection DbConnection()
        {
            return _databaseFactory.GetConnection();
        }

    }
}
