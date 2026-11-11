using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EgitimPortali.Core.Models;
using EgitimPortali.Core.Repositories;
namespace EgitimPortali.Core
{
    public class EventRepository : IEventRepository
    {
        private readonly List<Event> _etkinlikListesi = new List<Event>();

        public EventRepository()
        {
            Event etkinlik1 = new Event
            {
                Id = 1,
                Title = "C# Nesne Tabanlı Modelleme Atölyesi",
                Slug = "csharp-nesne-tabanli-modelleme",
                Description = "C# ile OOP temellerini öğreniyoruz.",
                StartDate = DateTime.UtcNow.AddDays(2),
                EndDate = DateTime.UtcNow.AddDays(2).AddHours(3),
                LocationType = "Online",
                OnlineMeetingUrl = "https://zoom.us/j/123456789",
                CategoryId = 1,
                OrganizerUnitId = 1,
                Quota = 40
            };
            _etkinlikListesi.Add(etkinlik1);

            Event etkinlik2 = new Event
            {
                Id = 2,
                Title = "Git ve GitHub Temelleri",
                Slug = "git-ve-github-temelleri",
                Description = "Versiyon kontrol sistemlerine giriş.",
                StartDate = DateTime.UtcNow.AddDays(5),
                EndDate = DateTime.UtcNow.AddDays(5).AddHours(2),
                LocationType = "Yüz Yüze",
                PhysicalAddress = "Teknokent Konferans Salonu, Ankara",
                CategoryId = 2,
                OrganizerUnitId = 2,
                Quota = null 
            };
            _etkinlikListesi.Add(etkinlik2);
        }

        public async Task<(List<Event> Etkinlikler, int ToplamKayit)> TumEtkinlikleriGetirAsync(string? search = null, int? categoryId = null, DateTime? fromDate = null, DateTime? toDate = null, string? sortBy = "date", string? sortOrder = "asc", int page = 1, int pageSize = 20)
        {
            await Task.Delay(1000);

            var query = _etkinlikListesi.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var lowerSearch = search.ToLower();

                query = query.Where(e =>
                    (e.Title != null && e.Title.ToLower().Contains(lowerSearch)) ||
                    (e.Description != null && e.Description.ToLower().Contains(lowerSearch))
                );
            }

            if (categoryId.HasValue)
            {
                query = query.Where(e => e.CategoryId == categoryId.Value);
            }

            if (fromDate.HasValue)
            {
                query = query.Where(e => e.StartDate >= fromDate.Value);
            }

            if (toDate.HasValue)
            {
                query = query.Where(e => e.StartDate <= toDate.Value);
            }

            int toplamKayit = query.Count();

            var sayfalanmisVeri = query.Skip((page - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToList();

            return (sayfalanmisVeri, toplamKayit);
        }

        public async Task<Event?> IdIleGetirAsync(int id)
        {
            await Task.Delay(500);

            var etkinlik = _etkinlikListesi.FirstOrDefault(e => e.Id == id);

            if (etkinlik == null)
            {
                throw new Exception($"Sistem Kayıt Hatası: {id} numaralı ID'ye sahip bir etkinlik veritabanında mevcut değil!");
            }

            return etkinlik;
        }

        public async Task EtkinlikEkleAsync(Event yeniEtkinlik)
        {
            await Task.Delay(500);
            yeniEtkinlik.Id = _etkinlikListesi.Max(e => e.Id) + 1;
            _etkinlikListesi.Add(yeniEtkinlik);
        }

        public async Task<Event?> SlugIleGetirAsync(string slug)
        {
            await Task.Delay(500);
            return _etkinlikListesi.FirstOrDefault(e => e.Slug == slug);
        }
    }
}