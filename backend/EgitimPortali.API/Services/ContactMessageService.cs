using System;
using System.Threading.Tasks;
using EgitimPortali.API.DTOs;

namespace EgitimPortali.API.Services
{
    public class ContactMessageService : IContactMessageService
    {
        public async Task<ContactMessageDto?> GetByIdAsync(int id)
        {
            await Task.CompletedTask;
            return null;
        }

        public async Task<ContactMessageDto> CreateMessageAsync(CreateContactMessageDto newDto)
        {
            await Task.CompletedTask;

            return new ContactMessageDto
            {
                Id = 1,
              
                SenderName = newDto.SenderName.Trim(),

              
                SenderEmail = newDto.SenderEmail.Trim().ToLower(),

                Subject = newDto.Subject.Trim(),
                Message = newDto.Message.Trim(),

                CreatedAt = DateTime.UtcNow,
                IsRead = false
            };
        }
    }
}