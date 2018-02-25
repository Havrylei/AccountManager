using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AccountManager.DAL.Entities;
using AccountManager.DAL.Infrastructure;
using AccountManager.DAL.Interfaces;
using System.Linq.Expressions;

namespace AccountManager.DAL.Repositories
{
    public class UserRatingRepository : IUserRatingRepository
    {
        private readonly Context _context;

        public UserRatingRepository(Context context)
        {
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Create(UserRating entity)
        {
            await _context.UsersRaitings.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<UserRating> Get(long ID)
        {
            UserRating result = await _context.UsersRaitings.FindAsync(ID);
            _context.Entry(result).State = EntityState.Detached;

            return result;
        }
    }
}
