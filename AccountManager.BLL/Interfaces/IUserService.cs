﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using AccountManager.BLL.DTO;
using AccountManager.DAL.Entities;

namespace AccountManager.BLL.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto> Get(string id);
        Task<UserDto> Create(RegistrateUserDto dto);
        Task<EditUserDto> Edit(string id);
        Task<ClaimsIdentity> Identity(string login, string password);
        Task<EditUserDto> Update(string id, EditUserDto dto);
        Task<bool> Exists(Expression<Func<User, bool>> predicate);
    }
}
