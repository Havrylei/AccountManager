using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AccountManager.BLL.DTO;
using AccountManager.BLL.Interfaces;
using AccountManager.DAL.Entities;
using AccountManager.DAL.Interfaces;

namespace AccountManager.BLL.Services
{
    public class UserRatingService : IUserRatingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserRatingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork
                ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }
        
        public async Task Create(UserRatingDto dto)
        {
            UserRating entity = _mapper.Map<UserRating>(dto);

            await _unitOfWork.UserRatings.Create(entity);
        }

        public async Task<UserRatingDto> Get(long ID)
        {
            UserRating result = await _unitOfWork.UserRatings.Get(ID);
            UserRatingDto dto = _mapper.Map<UserRatingDto>(result);

            return dto;
        }
    }
}
