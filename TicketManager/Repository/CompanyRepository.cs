using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Entities;
using TicketManager.Factories;

namespace TicketManager.Repository
{
    internal class CompanyRepository : ICompanyRepository
    {
        private readonly IDatabaseFactory _databaseFactory;
        public CompanyRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public async Task<Company> GetCompanyByIDAsync(int companyID)
        {
            using var connection = await _databaseFactory.GetConnectionAsync();

            string query = @"SELECT * FROM companies WHERE id = @companyID";

            return await connection.QueryFirstOrDefaultAsync<Company>(query, new { companyID });
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            using var connection = await _databaseFactory.GetConnectionAsync();

            string query = @"SELECT * FROM companies";

            return await connection.QueryAsync<Company>(query);
        }

        public async Task<IEnumerable<Company>> GetAllAsync(bool onlyEnabled)
        {
            using var connection = await _databaseFactory.GetConnectionAsync();

            string query = @"
            SELECT * FROM companies
            WHERE
                @onlyEnabled = 0 OR is_deleted = 0
            ";

            return await connection.QueryAsync<Company>(query, new { onlyEnabled });
        }

        public async Task<int> CreateAsync(string name)
        {
            using var connection = await _databaseFactory.GetConnectionAsync();

            string query = @"
            INSERT INTO companies(name)
            VALUES(@name);

            SELECT last_insert_rowid();
            ";

            return await connection.ExecuteScalarAsync<int>(query, new { name });
        }

        public async Task<int> UpdateAsync(string name, int companyID)
        {
            using var connection = await _databaseFactory.GetConnectionAsync();

            string query = @"
            UPDATE companies
            SET
                name = @name
            WHERE
                id = @companyID
            ";

            return await connection.ExecuteAsync(query, new { name, companyID });
        }

        public async Task<int> DeleteAsync(int companyID)
        {
            using var connection = await _databaseFactory.GetConnectionAsync();

            string query = @"
            UPDATE companies
            SET
                is_deleted = 1
            WHERE
                id = @companyID
            ";

            return await connection.ExecuteAsync(query, new { companyID });
        }
    }
}
