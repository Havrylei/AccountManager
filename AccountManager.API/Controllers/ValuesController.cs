using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccountManager.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;

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

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(await _logic.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _logic.Get(id));
        }
    }
}
