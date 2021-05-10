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
    public class CommentRepository : ICommentRepository
    {
        private readonly IDatabaseFactory _databaseFactory;

        public CommentRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public async Task<int> Create(Comment comment)
        {
            using var conn = await DbConnectionAsync();

            string query =
                @"INSERT INTO Comments(user_id,ticket_id,content)
                    VALUES(@userID,@ticketID,@content);

                SELECT last_insert_rowid();";

            DynamicParameters parameters = new();

            parameters.Add("userID",comment.UserID);
            parameters.Add("ticketID",comment.TicketID);
            parameters.Add("content",comment.Content);

            return await conn.ExecuteScalarAsync<int>(query, parameters);
        }

        public async Task<int> Delete(int commentID)
        {
            using var conn = await DbConnectionAsync();

            string query = "DELETE FROM Comments WHERE id = @commentID";

            return await conn.ExecuteAsync(query, new { commentID });
        }

        public async Task<IEnumerable<Comment>> GetAll(int ticketID)
        {
            using var conn = await DbConnectionAsync();

            string query = "SELECT * FROM Comments WHERE ticket_id = @ticketID";

            return await conn.QueryAsync<Comment>(query, new { ticketID });
        }

        public async Task<Comment> GetByID(int id)
        {
            using var conn = await DbConnectionAsync();

            string query = "SELECT * FROM Comments WHERE id = @id";

            return await conn.QueryFirstOrDefaultAsync<Comment>(query, new { id });
        }

        public async Task<int> GetTicketIDFromComment(int commentID)
        {
            using var conn = await DbConnectionAsync();

            string query = "SELECT ticket_id FROM Comments WHERE id = @commentID ";

            return await conn.ExecuteScalarAsync<int>(query, new { commentID });
        }

        public async Task<int> GetLastCommentIDFromTicket(int ticketID)
        {
            using var conn = await DbConnectionAsync();

            string query = "SELECT id FROM Comments WHERE ticket_id = @ticketID ORDER BY creation_date desc";

            return await conn.ExecuteScalarAsync<int>(query, new { ticketID });
        }

        public async Task<int> Update(Comment comment)
        {
            using var conn = await DbConnectionAsync();

            string query =
                @"UPDATE Comments
                    SET 
                        content = @content
                    WHERE
                        id = @commentID";

            DynamicParameters parameters = new();

            parameters.Add("id", comment.ID);
            parameters.Add("content", comment.Content);

            return await conn.ExecuteAsync(query, parameters);
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
