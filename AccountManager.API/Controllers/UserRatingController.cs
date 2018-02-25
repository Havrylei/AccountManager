using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccountManager.BLL.Interfaces;
using AccountManager.BLL.DTO;

namespace AccountManager.API.Controllers
{
    [Route("userRatings")]
    public class UserRatingController : Controller
    {
        private readonly IUserRatingService _logic;

        public UserRatingController(IUserRatingService logic)
        {
            _logic = logic;
        }

        [HttpGet]
        public async Task<IActionResult> Get(long ID)
        {
            return Ok(await _logic.Get(ID));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]UserRatingDto dto)
        {
            await _logic.Create(dto);

            return Ok();
        }
    }
}
