using System;
using AutoMapper;
using AccountManager.BLL.DTO;
using AccountManager.DAL.Entities;

namespace AccountManager.BLL.Infrastructure.Profiles
{
    public class RegistrateUserProfile : Profile
    {        
        public RegistrateUserProfile()
        {
            CreateMap<RegistrateUserDto, User>()
                .ForMember(m => m.UserName, c => c.MapFrom(d => d.Login))
                .ForMember(m => m.FirstName, c => c.MapFrom(d => d.FirstName))
                .ForMember(m => m.LastName, c => c.MapFrom(d => d.LastName))
                .ForMember(m => m.Email, c => c.MapFrom(d => d.Email))
                .ForMember(m => m.GradeID, c => c.MapFrom(d => d.GradeID))
                .ForMember(m => m.RegistrationDate, c => c.MapFrom(d => DateTime.Now))
                .ForMember(m => m.EnterDate, c => c.MapFrom(d => DateTime.Now))
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
