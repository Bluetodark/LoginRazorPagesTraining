using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByUsername(string username);
        public void CreateUserInDb(string username, string password);
    }
}
