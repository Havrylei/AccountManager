using AutoMapper;
using AccountManager.BLL.DTO;
using AccountManager.DAL.Entities;

namespace AccountManager.BLL.Infrastructure.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(m => m.ID, c => c.MapFrom(d => d.ID))
                .ForMember(m => m.Login, c => c.MapFrom(d => d.Login))
                .ForMember(m => m.FirstName, c => c.MapFrom(d => d.FirstName))
                .ForMember(m => m.LastName, c => c.MapFrom(d => d.LastName))
                .ForMember(m => m.GroupID, c => c.MapFrom(d => d.GroupID))
                .ForMember(m => m.Grade, c => c.MapFrom(d => new GradeDto()
                {
                    ID = d.Group.ID,
                    Name = d.Group.Name
                }))
                .ForMember(m => m.GroupID, c => c.MapFrom(d => d.GroupID))
                .ForMember(m => m.Group, c => c.MapFrom(d => new GroupDto()
                {
                    ID = d.Group.ID,
                    Name = d.Group.Name
                }))
                .ForMember(m => m.RegistrationDate, c => c.MapFrom(d => d.RegistrationDate))
                .ForMember(m => m.EnterDate, c => c.MapFrom(d => d.EnterDate))
                .ForMember(m => m.BirthDate, c => c.MapFrom(d => d.BirthDate))
                .ForMember(m => m.Phone, c => c.MapFrom(d => d.Phone))
                .ForMember(m => m.CountryID, c => c.MapFrom(d => d.CountryID))
                .ForMember(m => m.Country, c => c.MapFrom(d => new CountryDto()
                {
                    ID = d.Group.ID,
                    Name = d.Group.Name
                }))
                .ForMember(m => m.City, c => c.MapFrom(d => d.City))
                .ForMember(m => m.Avatar, c => c.MapFrom(d => d.Avatar))
                .ForMember(m => m.HidePhone, c => c.MapFrom(d => d.HidePhone))
                .ForMember(m => m.HideEmail, c => c.MapFrom(d => d.HideEmail))
                .ForAllOtherMembers(m => m.Ignore());

            CreateMap<UserDto, User>()
                .ForMember(m => m.ID, c => c.MapFrom(d => d.ID))
                .ForMember(m => m.Login, c => c.MapFrom(d => d.Login))
                .ForMember(m => m.FirstName, c => c.MapFrom(d => d.FirstName))
                .ForMember(m => m.LastName, c => c.MapFrom(d => d.LastName))
                .ForMember(m => m.GroupID, c => c.MapFrom(d => d.GroupID))
                .ForMember(m => m.GroupID, c => c.MapFrom(d => d.GroupID))
                .ForMember(m => m.RegistrationDate, c => c.MapFrom(d => d.RegistrationDate))
                .ForMember(m => m.EnterDate, c => c.MapFrom(d => d.EnterDate))
                .ForMember(m => m.BirthDate, c => c.MapFrom(d => d.BirthDate))
                .ForMember(m => m.Phone, c => c.MapFrom(d => d.Phone))
                .ForMember(m => m.CountryID, c => c.MapFrom(d => d.CountryID))
                .ForMember(m => m.City, c => c.MapFrom(d => d.City))
                .ForMember(m => m.Avatar, c => c.MapFrom(d => d.Avatar))
                .ForMember(m => m.HidePhone, c => c.MapFrom(d => d.HidePhone))
                .ForMember(m => m.HideEmail, c => c.MapFrom(d => d.HideEmail))
                .ForAllOtherMembers(m => m.Ignore());
        }
    }
}
