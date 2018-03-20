using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AccountManager.DAL.Entities;
using AccountManager.DAL.Interfaces;
using AccountManager.DAL.Infrastructure;

namespace AccountManager.DAL.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        private readonly Context _context;

        public GenderRepository(Context context)
        {
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Gender>> GetAll()
        {
            IEnumerable<Gender> result = await (
                from g in _context.Genders
                orderby g.ID ascending
                select g)
                .ToListAsync();

            return result;
        }
    }
}
