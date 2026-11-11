using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EgitimPortali.API.DTOs;

namespace EgitimPortali.API.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private static readonly List<AnnouncementDto> _announcements = new();
        private static int _nextId = 1;

        public List<AnnouncementDto> GetAll()
        {
            return _announcements;
        }

        public void Add(CreateAnnouncementDto createDto)
        {
            var announcement = new AnnouncementDto
            {
                Id = _nextId++,
                Title = createDto.Title,
                Content = createDto.Content,
                CreatedAt = DateTime.Now,
                IsActive = createDto.IsActive
            };

            _announcements.Add(announcement);
        }

 
        public async Task<List<AnnouncementDto>> TumDuyurulariGetirAsync()
        {
            return await Task.FromResult(GetAll());
        }

        public async Task DuyuruEkleAsync(CreateAnnouncementDto createDto)
        {
            Add(createDto);
            await Task.CompletedTask;
        }
    }
}