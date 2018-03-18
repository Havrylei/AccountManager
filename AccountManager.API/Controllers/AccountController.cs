using System;
using System.Threading.Tasks;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using AccountManager.BLL.DTO;
using AccountManager.BLL.Interfaces;
using AccountManager.API.Models;
using AccountManager.API.Infrastructure.Filters;

namespace AccountManager.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors(Startup.CorsPolicy)]
    public class AccountController : Controller
    {
        private readonly IUserService _logic;

        public AccountController(IUserService logic)
        {
            _logic = logic
                ?? throw new ArgumentNullException(nameof(logic));
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _logic.GetAll());
        }

        [Authorize]
        [HttpGet("personal")]
        public async Task<IActionResult> GetPersonalInfo()
        {
            var result = await _logic.Get(User.Identity.Name);

            if (result == null)
            {
                return new BadRequestObjectResult(new { Info = "User doesn't exist." });
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _logic.Get(id);

            if (result == null)
            {
                return new BadRequestObjectResult(new { Info = "User doesn't exist." });
            }

            return Ok(result);
        }

        [HttpPost("token")]
        [ValidateModel]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateDto dto)
        {
            ClaimsIdentity identity = await _logic.Identity(dto);

            if (identity == null)
            {
                return new BadRequestObjectResult(new { reason = "Wrong login or password." });
            }
            
            JwtSecurityToken jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: DateTime.UtcNow,
                    claims: identity.Claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            string token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return Ok(token);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Registration([FromBody] RegistrateUserDto dto)
        {
            if (await _logic.Exists(u => u.UserName == dto.Login))
            {
                return new BadRequestObjectResult(new { Login = $"{dto.Login} is already exist." });
            }

            if (await _logic.Exists(u => u.Email == dto.Email))
            {
                return new BadRequestObjectResult(new { Login = $"{dto.Email} is already in use." });
            }

            await _logic.Create(dto);

            return Ok();
        }

        [Authorize]
        [HttpPatch]
        public async Task<IActionResult> Edit()
        {
            string id = User.Identity.Name;

            EditUserDto dto = await _logic.Edit(id);

            if (dto == null)
            {
                return new BadRequestObjectResult(new { Info = "User doesn't exist." });
            }

            return Ok(dto);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EditUserDto dto)
        {
            string id = User.Identity.Name;

            if (await _logic.Exists(u => u.Email == dto.Email && u.Id != id))
            {
                return new BadRequestObjectResult(new { Login = $"{dto.Email} is already in use." });
            }

            await _logic.Update(id, dto);

            return Ok();
        }
    }
}
