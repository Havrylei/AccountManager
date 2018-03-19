using Microsoft.EntityFrameworkCore;
using AccountManager.DAL.Entities;

namespace AccountManager.DAL.Infrastructure
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<UserRating> UsersRaitings { get; set; }
        public DbSet<Message> Messages { get; set; }

        public Context(DbContextOptions<Context> context)
            : base(context)
        {

        }
    }
}
