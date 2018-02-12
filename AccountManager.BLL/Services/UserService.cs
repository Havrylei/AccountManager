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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork
                ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            IEnumerable<User> result = await _unitOfWork.Users.GetAll();
            IEnumerable<UserDto> list = _mapper.Map<IEnumerable<UserDto>>(result);

            return list;
        }

        public async Task<UserDto> Get(long id)
        {
            User result = await _unitOfWork.Users.Get(id);
            UserDto dto = _mapper.Map<UserDto>(result);

            return dto;
        }

        public async Task<bool> Exists(Expression<Func<User, bool>> predicate)
        {
            bool result = await _unitOfWork.Users.Exists(predicate);

            return result;
        }
    }
}
