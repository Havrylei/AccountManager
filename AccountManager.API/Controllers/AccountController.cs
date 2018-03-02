using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccountManager.BLL.DTO;
using AccountManager.BLL.Interfaces;
using AccountManager.API.Infrastructure.Filters;

namespace AccountManager.API.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IUserService _logic;

        public AccountController(IUserService logic)
        {
            _logic = logic;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<UserDto> Registration(RegistrateUserDto dto)
        {
            return await _logic.Create(dto);
        }
    }
}
