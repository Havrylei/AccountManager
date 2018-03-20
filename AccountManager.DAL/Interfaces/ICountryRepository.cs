using System.Threading.Tasks;
using System.Collections.Generic;
using AccountManager.DAL.Entities;

namespace AccountManager.DAL.Interfaces
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAll();
    }
}
