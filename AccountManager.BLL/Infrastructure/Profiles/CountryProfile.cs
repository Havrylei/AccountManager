using AutoMapper;
using AccountManager.BLL.DTO;
using AccountManager.DAL.Entities;

namespace AccountManager.BLL.Infrastructure.Profiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryDto>()
                .ForMember(m => m.ID, c => c.MapFrom(d => d.ID))
                .ForMember(m => m.Name, c => c.MapFrom(d => d.Name))
                .ForAllOtherMembers(m => m.Ignore());
        }
    }
}
