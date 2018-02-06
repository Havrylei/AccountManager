using Microsoft.EntityFrameworkCore;
using AccountManager.DAL.Entities;

namespace AccountManager.DAL.Infrastructure
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Country> Countries { get; set; }

        public Context(DbContextOptions<Context> context)
            : base(context)
        {

        }
    }
}
