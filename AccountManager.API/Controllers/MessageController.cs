using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccountManager.BLL.Interfaces;
using AccountManager.BLL.DTO;
using System;
using System.Collections.Generic;

namespace AccountManager.API.Controllers
{
    [Route("api/Messages")]
    public class MessageController : Controller
    {
        private readonly IMessageService _service;

        public MessageController(IMessageService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service)); 
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MessageDto dto)
        {
            await _service.Create(dto);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] long id)
        {
            MessageDto result = await _service.Get(id);

            return Ok(result);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll([FromQuery] long receiverId, long senderId)
        {
            IEnumerable<MessageDto> result = await _service.GetAll(receiverId, senderId);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] long Id)
        {
            await _service.Delete(Id);

            return Ok();
        }
    }
}
