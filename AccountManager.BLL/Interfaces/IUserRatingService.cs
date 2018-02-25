using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountManager.BLL.DTO;
using AccountManager.DAL.Entities;

namespace AccountManager.BLL.Interfaces
{
    public interface IUserRatingService
    {
        Task Create(UserRatingDto dto);
        Task<UserRatingDto> Get(long ID);
    }
}
