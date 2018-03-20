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
    public class CountryRepository : ICountryRepository
    {
        private readonly Context _context;

        public CountryRepository(Context context)
        {
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            IEnumerable<Country> result = await (
                from g in _context.Countries
                orderby g.Name ascending
                select g)
                .ToListAsync();

            return result;
        }
    }
}
