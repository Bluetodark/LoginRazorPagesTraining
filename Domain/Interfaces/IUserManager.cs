using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserManager
    {
        List<User> GetUsers();
        bool ValidateUser(string username, string password);
        User GetUserById(int id);
        bool CreateUser(string username, string password);
        void DeleteUser(int id);
    }
}
