using AutoMapper;
using AccountManager.BLL.DTO;
using AccountManager.DAL.Entities;

namespace AccountManager.BLL.Infrastructure.Profiles
{
    public class UserRatingProfile : Profile
    {
        public UserRatingProfile()
        {
            CreateMap<UserRating, UserRatingDto>()
                .ForMember(m => m.ID, c => c.MapFrom(d => d.ID))
                .ForMember(m => m.ReciverID, c => c.MapFrom(d => d.ReciverID))
                .ForMember(m => m.SenderID, c => c.MapFrom(d => d.SenderID))
                .ForAllOtherMembers(m => m.Ignore());

            CreateMap<UserRatingDto, UserRating>()
                .ForMember(m => m.ID, c => c.MapFrom(d => d.ID))
                .ForMember(m => m.ReciverID, c => c.MapFrom(d => d.ReciverID))
                .ForMember(m => m.SenderID, c => c.MapFrom(d => d.SenderID))
                .ForAllOtherMembers(m => m.Ignore());

        }
    }
}
