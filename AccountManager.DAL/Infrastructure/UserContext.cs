using AccountManager.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AccountManager.DAL.Infrastructure
{
    public class UserContext : IdentityDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Country> Countries { get; set; }

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
    }
}
