using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Security.Claims;
using AutoMapper;
using AccountManager.BLL.DTO;
using AccountManager.BLL.Interfaces;
using AccountManager.DAL.Entities;
using AccountManager.DAL.Interfaces;

namespace AccountManager.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IIdentityUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IIdentityUnitOfWork unitOfWork, IMapper mapper)
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

        public async Task<UserDto> Get(string id)
        {
            User result = await _unitOfWork.Users.Get(id);
            UserDto dto = _mapper.Map<UserDto>(result);

            return dto;
        }

        public async Task<ClaimsIdentity> Identity(AuthenticateDto dto)
        {
            User user = await _unitOfWork.Users.GetByLogin(dto.Login);

            if (user == null)
            {
                return null;
            }

            if (!await _unitOfWork.Users.CheckPassword(user, dto.Password))
            {
                return null;
            }

            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, "User")
                };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", 
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            return claimsIdentity;
        }

        public async Task<EditUserDto> Edit(string id)
        {
            User result = await _unitOfWork.Users.Get(id);
            EditUserDto dto = _mapper.Map<EditUserDto>(result);

            return dto;
        }

        public async Task Create(RegistrateUserDto dto)
        {
            await _unitOfWork.Users.Create(_mapper.Map<User>(dto), dto.Password);
        }

        public async Task Update(string id, EditUserDto dto)
        {
            User entity = await _unitOfWork.Users.Get(id);

            entity.Email = dto.Email;
            entity.GenderID = dto.GenderID;
            entity.BirthDate = dto.BirthDate;
            entity.Phone = dto.Phone;
            entity.CountryID = dto.CountryID;
            entity.City = dto.City;
            entity.Avatar = dto.Avatar;
            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;
            entity.HideEmail = dto.HideEmail;
            entity.HidePhone = dto.HidePhone;

            await _unitOfWork.Users.Update(entity);
        }

        public async Task<bool> Exists(Expression<Func<User, bool>> predicate)
        {
            bool result = await _unitOfWork.Users.Exists(predicate);

            return result;
        }
    }
}
