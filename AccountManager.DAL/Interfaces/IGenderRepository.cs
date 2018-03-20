using System.Threading.Tasks;
using System.Collections.Generic;
using AccountManager.DAL.Entities;

namespace AccountManager.DAL.Interfaces
{
    public interface IGenderRepository
    {
        Task<IEnumerable<Gender>> GetAll();
    }
}
