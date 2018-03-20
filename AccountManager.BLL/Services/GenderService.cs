using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountManager.BLL.DTO;
using AccountManager.BLL.Interfaces;
using AccountManager.DAL.Entities;
using AccountManager.DAL.Interfaces;
using AutoMapper;

namespace AccountManager.BLL.Services
{
    public class GenderService : IGenderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork
                ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<GenderDto>> GetAll()
        {
            IEnumerable<Gender> result = await _unitOfWork.Genders.GetAll();
            IEnumerable<GenderDto> list = _mapper.Map<IEnumerable<GenderDto>>(result);

            return list;
        }
    }
}
