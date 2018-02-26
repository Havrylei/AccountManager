using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountManager.DAL.Entities;
namespace AccountManager.DAL.Interfaces
{
    public interface IMessageRepository
    {
        Task Create(Message entity);
        Task<Message> Get(long id);
        Task<IEnumerable<Message>> GetAll(long receiverID, long senderID);
        Task Delete(long id);
    }
}
