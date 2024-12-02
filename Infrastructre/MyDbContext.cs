using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=logintraining;user=app;password=app;", new MySqlServerVersion(new Version(8, 2, 12))); // Use your actual MySQL version
        }
    }
}
