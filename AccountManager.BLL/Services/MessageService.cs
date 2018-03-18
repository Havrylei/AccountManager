using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AccountManager.BLL.DTO;
using AccountManager.BLL.Interfaces;
using AccountManager.DAL.Entities;
using AccountManager.DAL.Interfaces;

namespace AccountManager.BLL.Infrastructure.Profiles
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MessageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork
                ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Create(MessageDto dto)
        {
            Message entity = _mapper.Map<Message>(dto);

            await _unitOfWork.Messages.Create(entity);
        }

        public async Task<MessageDto> Get(long id)
        {
            Message result = await _unitOfWork.Messages.Get(id);
            MessageDto dto = _mapper.Map<MessageDto>(result);

            return dto;
        }

        public async Task<IEnumerable<MessageDto>> GetAll(long receiverId, long senderId)
        {
            IEnumerable<Message> result = await _unitOfWork.Messages.GetAll(receiverId, senderId);
            IEnumerable<MessageDto> list = _mapper.Map<IEnumerable<MessageDto>>(result);

            return list;
        }

        public async Task Delete(long id)
        {
            await _unitOfWork.Messages.Delete(id);
        }
    }
}
