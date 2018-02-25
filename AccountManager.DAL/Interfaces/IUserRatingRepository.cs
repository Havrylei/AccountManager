using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountManager.DAL.Entities;

namespace AccountManager.DAL.Interfaces
{
    public interface IUserRatingRepository
    {
        Task Create(UserRating entity);
        Task<UserRating> Get(long ID);
    }
}
