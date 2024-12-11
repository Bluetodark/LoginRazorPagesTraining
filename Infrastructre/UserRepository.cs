using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Data.Common;
using Domain.Interfaces;
using Domain;

namespace Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;

        public UserRepository(MyDbContext context)
        {
            _context = context;
        }

        public User GetUserByUsername(string username)
        {
            var connection = _context.Database.GetDbConnection();
            connection.Open();

            const string query = "SELECT ID, username, password, email FROM accounts WHERE username = @username";

            using var command = connection.CreateCommand();
            command.CommandText = query;

            var parameter = command.CreateParameter();
            parameter.ParameterName = "@username";
            parameter.Value = username;
            command.Parameters.Add(parameter);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                User user = new User()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("ID")),
                    Username = reader.GetString(reader.GetOrdinal("username")),
                    Password = reader.GetString(reader.GetOrdinal("password")),
                    Email = reader.GetString(reader.GetOrdinal("email"))
                };

                connection.Close();

                return user;
            }
            connection.Close();
            return null;
        }

        public void CreateUserInDb(string username, string password)
        {
            const string query = "INSERT INTO accounts (username, password) VALUES (@username, @password)";

            var connection = _context.Database.GetDbConnection();
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = query;

            var usernameParam = command.CreateParameter();
            usernameParam.ParameterName = "@username";
            usernameParam.Value = username;
            command.Parameters.Add(usernameParam);

            var passwordParam = command.CreateParameter();
            passwordParam.ParameterName = "@password";
            passwordParam.Value = password;
            command.Parameters.Add(passwordParam);

            command.ExecuteNonQuery();

            connection.Close();
        }

        public List<User> GetUsers()
        {
            var connection = _context.Database.GetDbConnection();
            connection.Open();

            const string query = "SELECT ID, username, password, email FROM accounts";

            using var command = connection.CreateCommand();
            command.CommandText = query;

            using var reader = command.ExecuteReader();

            var users = new List<User>();

            while (reader.Read())
            {
                var user = new User
                {
                    Id = reader.GetInt32(reader.GetOrdinal("ID")),
                    Username = reader.GetString(reader.GetOrdinal("username")),
                    Password = reader.GetString(reader.GetOrdinal("password")),
                    Email = reader.GetString(reader.GetOrdinal("email"))
                };
                users.Add(user);
            }

            connection.Close();
            return users;
        }
    }
}