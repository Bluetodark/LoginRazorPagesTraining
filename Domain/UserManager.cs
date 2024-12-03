using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;

namespace Domain
{
    public class UserManager : Interfaces.IUserManager
    {
        public readonly Infrastructure.UserRepository _repository;
        private static List<User> users = new List<User>();

        public UserManager(UserRepository repository)
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

        public bool ValidateUser(User user)
        {
            return users.Any(user => user.Username == user.username && user.Password == user.password);
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

        public bool CreateUser(User user)
        {
            if (users.Any(user => user.Username == user.username))
            {
                return false; // Username already exists
            }

            users.Add(new User { Id = 1234, Username = user.username, Password = user.password });
            return true;
        }
    }
}