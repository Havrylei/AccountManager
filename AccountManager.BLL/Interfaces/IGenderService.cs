using System.Threading.Tasks;
using System.Collections.Generic;
using AccountManager.BLL.DTO;

namespace AccountManager.BLL.Interfaces
{
    public interface IGenderService
    {
        Task<IEnumerable<GenderDto>> GetAll();
    }
}
