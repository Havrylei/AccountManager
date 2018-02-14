using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AccountManager.DAL.Entities;
using AccountManager.DAL.Infrastructure;
using AccountManager.DAL.Interfaces;
using System.Linq.Expressions;

namespace AccountManager.DAL.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Context _context;

        public MessageRepository(Context context)
        {
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Create(Message entity)
        {
            await _context.Messages.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Message> Get(long id)
        {
            Message result = await _context.Messages.FindAsync(id);
            
            _context.Entry(result).State = EntityState.Detached;
            
            return result;
        }

        public async Task<IEnumerable<Message>> GetAll(long receiverID, long senderID)
        {
            return await (from n in _context.Messages
                          where n.ReciverID == receiverID && n.SenderID == senderID
                          orderby n.ID descending
                          select n).ToListAsync();
        }

        public async Task Delete(long id)
        {
            Message entity = await _context.Messages.FindAsync(id);

            _context.Messages.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
