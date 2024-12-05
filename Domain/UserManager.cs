using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserManager : Interfaces.IUserManager
    {
        public readonly Infrastructre.Interfaces.IUserRepository _repository;
        private static List<User> users = new List<User>();

        public UserManager(Infrastructre.Interfaces.IUserRepository repository)
        {
            _repository = repository;
        }

        public List<User> GetUsers()
        {
            users = new List<User>();
            var sqlQuery = "SELECT ID, username, password, email FROM accounts";

            using var reader = _repository.ExecuteSql(sqlQuery);

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

            return users;
        }

        public bool ValidateUser(string username, string password)
        {
            string Correctpassword = _repository.GetPasswordByUsername(username);
            return (Correctpassword == password);
        }

        public User GetUserById(int id)
        {
            // Implementation for fetching a user by ID
            return new User();
        }

        public void DeleteUser(int id)
        {
            // Implementation for deleting a user
        }


        public bool CreateUser(string username, string password)
        {
            if (users.Any(user => user.Username == username))
            {
                return false; // Username already exists
            }

            _repository.CreateUserInDb(username, password);

            users.Add(new User { Id = 1234, Username = username, Password = password });
            return true;
        }
    }
}