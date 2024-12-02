using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserManager
    {
        //hardcoded user list
        private static List<User> users = new List<User> {
            new User { ID = 1234, Username = "admin", Password = "1234" },
            new User { ID = 1235, Username = "user", Password = "password" }
        };
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

            users.Add(new User { ID = 1234, Username = username, Password = password }); 
            return true; 
        }
    }
}