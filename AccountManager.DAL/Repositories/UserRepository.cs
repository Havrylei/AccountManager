using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AccountManager.DAL.Entities;
using AccountManager.DAL.Infrastructure;
using AccountManager.DAL.Interfaces;

namespace AccountManager.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context
                ?? throw new ArgumentNullException(nameof(context)); 
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            IEnumerable<User> result = await (
                from u in _context.Users
                orderby u.ID descending
                select u)
                .Include(u => u.Grade)
                .Include(u => u.Group)
                .Include(u => u.Country)
                .ToListAsync();

            return result;
        }

        public async Task<User> Get(long id)
        {
            User result = await _context.Users
                .Where(u => u.ID == id)
                .Include(u => u.Grade)
                .Include(u => u.Group)
                .Include(u => u.Country)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<bool> Exists(long id)
        {
            return await _context.Users.AnyAsync(u => u.ID == id);
        }
    }
}
