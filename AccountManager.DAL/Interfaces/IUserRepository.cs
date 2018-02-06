﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AccountManager.DAL.Entities;

namespace AccountManager.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> Get(long id);
        Task<bool> Exists(long id);
    }
}
