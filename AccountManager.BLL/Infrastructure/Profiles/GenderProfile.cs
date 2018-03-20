using AutoMapper;
using AccountManager.BLL.DTO;
using AccountManager.DAL.Entities;

namespace AccountManager.BLL.Infrastructure.Profiles
{
    public class GenderProfile : Profile
    {
        public GenderProfile()
        {
            CreateMap<Gender, GenderDto>()
                .ForMember(m => m.ID, c => c.MapFrom(d => d.ID))
                .ForMember(m => m.Name, c => c.MapFrom(d => d.Name))
                .ForAllOtherMembers(m => m.Ignore());
        }
    }
}
