using Infrastructre.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Data.Common;

namespace Infrastructure
{
    public class UserRepository : IUserRepository
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

        public string GetPasswordByUsername(string username) {

            var Query = "SELECT password FROM accounts WHERE username=\"" + username + "\";";

            var reader = ExecuteSql(Query);

            if (reader.Read()) // Make sure to read the first record
            {
                string password = reader.GetString(reader.GetOrdinal("password"));

                if (!string.IsNullOrEmpty(password))
                {
                    return password;
                }
            }

            return "failed";
        }

        public void CreateUserInDb(string username, string password) {
            var Query = "INSERT INTO `accounts` (`ID`, `username`, `password`) VALUES (NULL, '"+username+"', '"+password+"');";

            var connection = _context.Database.GetDbConnection();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = Query;

            command.ExecuteNonQuery(); // Use ExecuteNonQuery for INSERT statements

            connection.Close(); // Close connection explicitly
            return;
        }
    }
}