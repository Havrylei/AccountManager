using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccountManager.BLL.DTO;
using AccountManager.BLL.Interfaces;
using AccountManager.API.Infrastructure.Filters;
using System;
using Microsoft.AspNetCore.Identity;
using AccountManager.DAL.Entities;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using AccountManager.API.Models;
using Microsoft.IdentityModel.Tokens;

namespace AccountManager.API.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _manager;
        private readonly IUserService _logic;

        public AccountController(IUserService logic, UserManager<User> manager)
        {
            _logic = logic
                ?? throw new ArgumentNullException(nameof(logic));
            _manager = manager
                ?? throw new ArgumentNullException(nameof(manager));
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(string login, string password)
        {
            ClaimsIdentity identity = await _logic.Identity(login, password);

            if (identity == null)
            {
                return new BadRequestObjectResult("Wrong login or password.");
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

        //[HttpPost]
        //[ValidateModel]
        //public async Task<IActionResult> Registration([FromBody] RegistrateUserDto dto)
        //{
        //    if (await _logic.Exists(u => u.UserName == dto.Login))
        //    {
        //        return new BadRequestObjectResult(new { Login = $"{dto.Login} is already exist."});
        //    }

        //    if (await _logic.Exists(u => u.Email == dto.Email))
        //    {
        //        return new BadRequestObjectResult(new { Login = $"{dto.Email} is already in use." });
        //    }

        //    return Ok(await _logic.Create(dto));
        //}

        [HttpPatch]
        public async Task<IActionResult> Edit([FromRoute] string id)
        {
            EditUserDto dto = await _logic.Edit(id);

            if (dto == null)
            {
                return new BadRequestObjectResult(new { Login = "User doesn't exist." });
            }

            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] EditUserDto dto)
        {
            if (await _logic.Exists(u => u.Email == dto.Email && u.Id != id))
            {
                return new BadRequestObjectResult(new { Login = $"{dto.Email} is already in use." });
            }

            EditUserDto result = await _logic.Update(id, dto);

            return Ok(result);
        }
    }
}
