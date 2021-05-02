using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Factories;
using TicketManager.Models;

namespace TicketManager.Repository
{
    public class CompanyRepository
    {
        private readonly IDatabaseFactory _databaseFactory;
        public CompanyRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        internal async Task<Company> GetCompanyByIDAsync(int companyID)
        {
            using var connection = await _databaseFactory.GetConnectionAsync();

            string query = @"
            SELECT * FROM companies WHERE id = @companyID
            ";

            return await connection.QueryFirstOrDefaultAsync<Company>(query,new { companyID });
        }

        internal async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            using var connection = await _databaseFactory.GetConnectionAsync();

            string query = @"
            SELECT * FROM companies
            ";

            return await connection.QueryAsync<Company>(query);
        }
        
        internal async Task<IEnumerable<Company>> GetCompaniesAsync(bool onlyEnabled)
        {
            using var connection = await _databaseFactory.GetConnectionAsync();

            string query = @"
            SELECT * FROM companies
            WHERE
                @onlyEnabled = 0 OR is_deleted = 0
            ";

            return await connection.QueryAsync<Company>(query);
        }

        internal async Task<int> Create(string name)
        {
            using var connection = await _databaseFactory.GetConnectionAsync();

            string query = @"
            INSERT INTO companies(name)
            VALUES(@name)
            ";

            return await connection.ExecuteAsync(query, new { name });
        }

        internal async Task<int> Update(string name, int companyID)
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

        internal async Task<int> DeleteAsync(int companyID)
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
