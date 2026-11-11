using System.Collections.Generic;
using System.Threading.Tasks;
using EgitimPortali.Core;
using EgitimPortali.Core.Models;
using EgitimPortali.API.DTOs;

namespace EgitimPortali.API.Services
{
    public interface IEventService
    {

        Task<PagedResponse<EventListDto>> TumEtkinlikleriGetirAsync(string? search = null, int? categoryId = null, DateTime? fromDate = null, DateTime? toDate = null, string? sortBy = "date", string? sortOrder = "asc", int page = 1, int pageSize = 20);

        Task<EventDetailDto?> SlugIleGetirAsync(string slug);

        Task EtkinlikEkleAsync(Event @event);
    }
}