using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserManager
    {
        bool CreateUser(User user);
        User GetUserById(int id);
        void DeleteUser(int id);
        bool ValidateUser(User user);
    }
}
