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
    public class TicketRepository : ITicketRepository
    {
        private readonly IDatabaseFactory _databaseFactory;

        public TicketRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }
 
        public async Task<int> Create(Ticket ticket)
        {
            using var conn = await DbConnectionAsync();

            string query = 
                @"INSERT INTO Tickets(subject,content,user_id,company_id)
                    VALUES(@subject,@content,@userID,@companyID)";

            DynamicParameters parameters = new();

            parameters.Add("subject", ticket.Subject);
            parameters.Add("content", ticket.Content);
            parameters.Add("userID", ticket.UserID);
            parameters.Add("companyID", ticket.CompanyID);

            return await conn.ExecuteAsync(query, parameters);
        }

        public async Task<int> Delete(int ticketID)
        {
            using var conn = await DbConnectionAsync();

            string query = "DELETE FROM Tickets WHERE id = @ticketID";

            return await conn.ExecuteAsync(query, new { ticketID });
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            using var conn = await DbConnectionAsync();

            string query = "SELECT * FROM Tickets";

            return await conn.QueryAsync<Ticket>(query);
        }

        public async Task<Ticket> GetTicketById(int ticketID)
        {
            using var conn = await DbConnectionAsync();

            string query = "SELECT * FROM Tickets WHERE id = @ticketID";

            return await conn.QueryFirstOrDefaultAsync<Ticket>(query, new { ticketID });
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByCompany(int companyID)
        {
            using var conn = await DbConnectionAsync();

            string query = "SELECT * FROM Tickets WHERE company_id = @companyID";

            return await conn.QueryAsync<Ticket>(query, new { companyID});
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByUser(int userID)
        {
            using var conn = await DbConnectionAsync();

            string query = "SELECT * FROM Tickets WHERE user_id = @userID";

            return await conn.QueryAsync<Ticket>(query, new { userID });
        }

        public async Task<int> ChangeTicketStatus(TicketStatus status, int ticketID)
        {
            using var conn = await DbConnectionAsync();

            string query = "UPDATE Tickets SET status = @status WHERE id = @ticketID";

            return await conn.ExecuteAsync(query, new { status,ticketID});
        }

        //public async Task<int> Update(Ticket ticket)
        //{
        //    throw new NotImplementedException();
        //}

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
