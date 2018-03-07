using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AccountManager.DAL.Entities;

namespace AccountManager.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> Get(string id);
        Task<User> GetByLogin(string login);
        Task<User> Create(User user, string password);
        Task<User> Update(User user);
        Task<bool> CheckPassword(User user, string password);
        Task<bool> Exists(Expression<Func<User, bool>> predicate);
    }
}
