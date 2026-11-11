using EgitimPortali.API.DTOs;
using EgitimPortali.Core;
using EgitimPortali.Core.Models;
using EgitimPortali.Core.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgitimPortali.API.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _repository;
        private readonly ILogger<EventService> _logger;

        public EventService(IEventRepository repository, ILogger<EventService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<PagedResponse<EventListDto>> TumEtkinlikleriGetirAsync(string? search = null, int? categoryId = null, DateTime? fromDate = null, DateTime? toDate = null, string? sortBy = "date", string? sortOrder = "asc", int page = 1, int pageSize = 20)
        {
            _logger.LogInformation("Etkinlikler listeleniyor... Arama: {Search}, Kategori ID: {CategoryId}, Sayfa: {Page}", search, categoryId, page);

            var (etkinlikler, toplamKayit) = await _repository.TumEtkinlikleriGetirAsync(search, categoryId, fromDate, toDate, sortBy, sortOrder, page, pageSize);

            var dtoList = etkinlikler.Select(e => new EventListDto
            {
                Id = e.Id,
                Title = e.Title,
                Slug = e.Slug,
                StartDate = e.StartDate,
                CategoryName = e.Category?.Name ?? "Kategorisiz"
            }).ToList();

            _logger.LogInformation("{Count} adet etkinlik başarıyla getirildi.", dtoList.Count);

            return new PagedResponse<EventListDto>(dtoList, page, pageSize, toplamKayit);
        }

        public async Task<Event?> IdIleGetirAsync(int id)
        {
            _logger.LogInformation("{EventId} numaralı etkinlik veritabanında aranıyor...", id);
            var etkinlik = await _repository.IdIleGetirAsync(id);

            if (etkinlik == null)
                _logger.LogWarning("Uyarı: Sistemde {EventId} numaralı bir etkinlik bulunamadı!", id);
            else
                _logger.LogInformation("{EventId} numaralı etkinlik başarıyla getirildi.", id);

            return etkinlik;
        }

        public async Task<EventDetailDto?> SlugIleGetirAsync(string slug)
        {
            _logger.LogInformation("'{Slug}' slug değerine sahip etkinlik veritabanında aranıyor...", slug);
            var etkinlik = await _repository.SlugIleGetirAsync(slug);

            if (etkinlik == null)
            {
                _logger.LogWarning("Uyarı: Sistemde '{Slug}' adında bir etkinlik bulunamadı!", slug);
                return null;
            }

            _logger.LogInformation("'{Slug}' slug değerli etkinlik başarıyla DTO'ya dönüştürüldü.", slug);

            return new EventDetailDto
            {
                Id = etkinlik.Id,
                Title = etkinlik.Title,
                Description = etkinlik.Description,
                StartDate = etkinlik.StartDate,
                EndDate = etkinlik.EndDate,
                LocationType = etkinlik.LocationType,
                Quota = etkinlik.Quota ?? 0,
                OrganizerUnitName = etkinlik.OrganizerUnit?.Name
            };
        }

        public async Task EtkinlikEkleAsync(Event @event)
        {
            _logger.LogInformation("Yeni etkinlik ekleme işlemi başlatıldı. Etkinlik Başlığı: {EventTitle}", @event.Title);
            await _repository.EtkinlikEkleAsync(@event);
            _logger.LogInformation("Etkinlik veritabanına başarıyla eklendi. Atanan ID: {EventId}", @event.Id);
        }
    }
}