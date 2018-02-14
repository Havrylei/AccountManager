using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountManager.BLL.DTO;
using AccountManager.DAL.Entities;

namespace AccountManager.BLL.Interfaces
{
    public interface IMessageService
    {
        Task Create(MessageDto dto);
        Task<MessageDto> Get(long id);
        Task<IEnumerable<MessageDto>> GetAll(long recieverId, long senderId);
        Task Delete(long id);
    }
}
