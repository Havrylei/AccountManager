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
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CountryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork
                ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<CountryDto>> GetAll()
        {
            IEnumerable<Country> result = await _unitOfWork.Countries.GetAll();
            IEnumerable<CountryDto> list = _mapper.Map<IEnumerable<CountryDto>>(result);

            return list;
        }
    }
}
