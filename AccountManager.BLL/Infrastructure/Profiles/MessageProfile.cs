using AutoMapper;
using AccountManager.BLL.DTO;
using AccountManager.DAL.Entities;
namespace AccountManager.BLL.Infrastructure.Profiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageDto>()
                .ForMember(m => m.ID, c => c.MapFrom(d => d.ID))
                .ForMember(m => m.Subject, c => c.MapFrom(d => d.Subject))
                .ForMember(m => m.Text, c => c.MapFrom(d => d.Text))
                .ForMember(m => m.CreateDate, c => c.MapFrom(d => d.CreateDate))
                .ForMember(m => m.ReciverID, c => c.MapFrom(d => d.ReciverID))
                .ForMember(m => m.SenderID, c => c.MapFrom(d => d.SenderID))
                .ForAllOtherMembers(m => m.Ignore());

            CreateMap<MessageDto, Message>()
                .ForMember(m => m.ID, c => c.MapFrom(d => d.ID))
                .ForMember(m => m.Subject, c => c.MapFrom(d => d.Subject))
                .ForMember(m => m.Text, c => c.MapFrom(d => d.Text))
                .ForMember(m => m.CreateDate, c => c.MapFrom(d => d.CreateDate))
                .ForMember(m => m.ReciverID, c => c.MapFrom(d => d.ReciverID))
                .ForMember(m => m.SenderID, c => c.MapFrom(d => d.SenderID))
                .ForAllOtherMembers(m => m.Ignore());

        }
    }
}
