using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EgitimPortali.Core.Models;

namespace EgitimPortali.Core.Repositories
{
    public interface IEventRepository
    {
        Task<(List<Event> Etkinlikler, int ToplamKayit)> TumEtkinlikleriGetirAsync(string? search = null, int? categoryId = null, DateTime? fromDate = null, DateTime? toDate = null, string? sortBy = "date", string? sortOrder = "asc", int page = 1, int pageSize = 20);

        Task<Event?> IdIleGetirAsync(int id);
        Task<Event?> SlugIleGetirAsync(string slug);
        Task EtkinlikEkleAsync(Event @event);
    }
}