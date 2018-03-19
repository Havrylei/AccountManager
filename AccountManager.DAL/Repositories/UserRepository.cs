using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AccountManager.DAL.Entities;
using AccountManager.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace AccountManager.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _manager;

        public UserRepository(UserManager<User> manager)
        {
            _manager = manager
                ?? throw new ArgumentNullException(nameof(manager)); 
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            IEnumerable<User> result = await (
                from u in _manager.Users
                orderby u.Id descending
                select u)
                .Include(u => u.Gender)
                .Include(u => u.Country)
                .ToListAsync();

            return result;
        }

        public async Task<User> Get(string id)
        {
            User result = await (
                from u in _manager.Users
                where u.Id == id
                select u)
                .Include(u => u.Gender)
                .Include(u => u.Country)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<User> GetByLogin(string login)
        {
            User result = await (
                from u in _manager.Users
                where u.UserName == login
                select u)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<bool> CheckPassword(User user, string password)
        {
            bool result = await _manager.CheckPasswordAsync(user, password);

            return result;
        }

        public async Task Create(User user, string password)
        {
            await _manager.CreateAsync(user, password);
        }

        public async Task Update(User user)
        {
            await _manager.UpdateAsync(user);
        }

        public async Task<bool> Exists(Expression<Func<User, bool>> predicate)
        {
            return await _manager.Users.AnyAsync(predicate);
        }
    }
}
