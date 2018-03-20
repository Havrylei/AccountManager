using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using AccountManager.BLL.Interfaces;

namespace AccountManager.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors(Startup.CorsPolicy)]
    public class CountryController : Controller
    {
        private readonly ICountryService _logic;

        public CountryController(ICountryService logic)
        {
            _logic = logic
                ?? throw new ArgumentNullException(nameof(logic));
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _logic.GetAll());
        }
    }
}
