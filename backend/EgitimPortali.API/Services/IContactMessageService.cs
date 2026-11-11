using EgitimPortali.API.DTOs;
using System.Threading.Tasks;

namespace EgitimPortali.API.Services
{
    public interface IContactMessageService
    {
        Task<ContactMessageDto?> GetByIdAsync(int id);
        Task<ContactMessageDto> CreateMessageAsync(CreateContactMessageDto newDto);
    }
}