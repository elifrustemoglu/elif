using System.Collections.Generic;
using System.Threading.Tasks;
using EgitimPortali.API.DTOs;

namespace EgitimPortali.API.Services
{
    public interface IAnnouncementService
    {
        Task<List<AnnouncementDto>> TumDuyurulariGetirAsync();
        Task DuyuruEkleAsync(CreateAnnouncementDto dto);
    }
}