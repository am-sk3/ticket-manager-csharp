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
    public class UserRepository : IUserRepository
    {
        private readonly IDatabaseFactory _databaseFactory;

        public UserRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public async Task<User> GetByID(int userID)
        {
            using var conn = await DbConnectionAsync();

            string query = "SELECT * FROM Users";

            return await conn.QueryFirstOrDefaultAsync<User>(query);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            using var conn = await DbConnectionAsync();

            string query = "SELECT * FROM Users";

            return await conn.QueryAsync<User>(query);
        }

        public async Task<IEnumerable<User>> GetAll(bool onlyEnabled)
        {
            using var conn = await DbConnectionAsync();

            string query = "SELECT * FROM Users";

            return await conn.QueryAsync<User>(query);
        }

        public async Task<int> Create(User user)
        {
            using var conn = await DbConnectionAsync();

            string query =
                @"INSERT INTO 
                    Users(name,email,password,creation_date,is_admin,is_enabled) 
                    VALUES(@name,@email,@password,@creation_date,@is_admin,@is_enabled);

                SELECT last_insert_rowid();";

            var parameters = new DynamicParameters();

            parameters.Add("name",user.Name);
            parameters.Add("email",user.Email);
            parameters.Add("password",user.Password);
            parameters.Add("creation_date",user.CreationDate);
            parameters.Add("is_admin",user.IsAdmin);
            parameters.Add("is_enabled",user.IsEnabled);

            return await conn.ExecuteScalarAsync<int>(query, parameters);
        }

        public async Task<int> Update(User user)
        {
            using var conn = await DbConnectionAsync();

            string query =
                @"UPDATE Users 
                    SET
                         name   = @name
                        ,email  = @email
                        ,password   = @password
                        ,creation_date   = @creation_date
                        ,is_admin   = @is_admin
                        ,is_enabled = @is_enabled
                    WHERE
                        ID = @id";

            var parameters = new DynamicParameters();

            parameters.Add("ID", user.ID);
            parameters.Add("name", user.Name);
            parameters.Add("email", user.Email);
            parameters.Add("password", user.Password);
            parameters.Add("creation_date", user.CreationDate);
            parameters.Add("is_admin", user.IsAdmin);
            parameters.Add("is_enabled", user.IsEnabled);

            return await conn.ExecuteAsync(query, parameters);
        }

        public async Task<int> Delete(int userID)
        {
            using var conn = await DbConnectionAsync();

            string query = "DELETE FROM Users WHERE ID = @userID";

            return await conn.ExecuteAsync(query, new { userID });
        }

        public async Task<int> ChangePassword(string password, int userID)
        {
            using var conn = await DbConnectionAsync();

            string query = "UPDATE Users SET password = @password WHERE ID = @userID";

            return await conn.ExecuteAsync(query, new { password, userID });
        }

        public async Task<User> GetByEmail(string email)
        {
            using var conn = await DbConnectionAsync();

            string query = "SELECT * FROM Users WHERE email = @email";

            return await conn.QueryFirstOrDefaultAsync(query, new { email });
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
