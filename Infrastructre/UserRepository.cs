using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;

namespace Infrastructure
{
    public class UserRepository
    {
        private readonly MyDbContext _context;

        public UserRepository(MyDbContext context)
        {
            _context = context;
        }

        public DbDataReader ExecuteSql(string sqlQuery)
        {
            var connection = _context.Database.GetDbConnection();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = sqlQuery;

            // Return the reader directly but ensure it is used and disposed properly by the caller
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}