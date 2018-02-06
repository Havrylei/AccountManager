using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManager.DAL.Entities;
using AccountManager.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AccountManager.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ValuesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.Users.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return Ok(await _unitOfWork.Users.Get(id));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Exists(long id)
        {
            return Ok(await _unitOfWork.Users.Exists(id));
        }
    }
}
