using Infrastructure;
using Microsoft.EntityFrameworkCore;

public class UserRepository
{
    private readonly MyDbContext _context;

    public UserRepository(MyDbContext context)
    {
        _context = context;
    }

    //public List<User> GetUsers()
    //{
    //    // Use raw SQL to query the 'accounts' table
    //    string sqlQuery = "SELECT Id, Username, Email FROM accounts";
    //    return _context.Users.FromSqlRaw(sqlQuery).ToList(); // Assumes you still want a list of users, but no automatic mapping
    //}
}