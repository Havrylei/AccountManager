using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccountManager.BLL.Interfaces;

namespace AccountManager.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IUserService _logic;

        public ValuesController(IUserService logic)
        {
            _logic = logic;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _logic.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return Ok(await _logic.Get(id));
        }

        [HttpPatch("{login}")]
        public async Task<IActionResult> Exists(string login)
        {
            return Ok(await _logic.Exists(u => u.Login == login));
        }
    }
}
