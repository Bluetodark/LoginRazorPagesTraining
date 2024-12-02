using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    //public class UserManager
    //{
    //    //hardcoded user list
    //    private static List<User> users = new List<User> {
    //        new User { ID = 1234, Username = "admin", Password = "1234" },
    //        new User { ID = 1235, Username = "user", Password = "password" }
    //    };
    //    public bool ValidateUser(string username, string password)
    //    {
    //        return users.Any(user => user.Username == username && user.Password == password);
    //    }

    //    public bool RegisterUser(string username, string password)
    //    {
    //        if (users.Any(user => user.Username == username))
    //        {
    //            return false; // Username already exists
    //        }

    //        users.Add(new User { ID = 1234, Username = username, Password = password }); 
    //        return true; 
    //    }
    //}
    public class UserManager
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

        public bool ValidateUser(string username, string password)
        {
            return users.Any(user => user.Username == username && user.Password == password);
        }

        public bool RegisterUser(string username, string password)
        {
            if (users.Any(user => user.Username == username))
            {
                return false; // Username already exists
            }

            users.Add(new User { Id = 1234, Username = username, Password = password });
            return true;
        }
    }
}