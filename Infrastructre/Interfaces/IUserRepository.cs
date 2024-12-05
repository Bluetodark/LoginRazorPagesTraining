using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructre.Interfaces
{
    public interface IUserRepository
    {
        string GetPasswordByUsername(string username);
        public DbDataReader ExecuteSql(string sqlQuery);
        public void CreateUserInDb(string username, string password);
    }
}
