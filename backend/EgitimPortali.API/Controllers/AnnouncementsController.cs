using Microsoft.AspNetCore.Mvc;
using EgitimPortali.API.DTOs;
using EgitimPortali.API.Services;

namespace staj_uygulamasi
{
    [ApiController]
    [Route("api/announcements")]
    public class AnnouncementsController : ControllerBase
    {
        private static readonly List<AnnouncementDto> _announcements = new()
        {
            new AnnouncementDto
            {
                Id = 1,
                Title = "Staj Programı Başladı",
                Content = "2026 Güz dönemi staj programı kapsamında API sözleşmeleri hazırlanıyor.",
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            }
        };

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AnnouncementDto>), StatusCodes.Status200OK)]
        public IActionResult GetAll([FromQuery] bool? isActive)
        {
            var sonuc = _announcements.AsEnumerable();

            if (isActive.HasValue)
            {
                sonuc = sonuc.Where(a => a.IsActive == isActive.Value);
            }

            return Ok(sonuc);
        }

        [HttpPost]
        [ProducesResponseType(typeof(AnnouncementDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] CreateAnnouncementDto dto)
        {
            var yeniDuyuru = new AnnouncementDto
            {
                Id = _announcements.Count + 1,
                Title = dto.Title,
                Content = dto.Content,
                CreatedAt = DateTime.UtcNow,
                IsActive = dto.IsActive
            };

            _announcements.Add(yeniDuyuru);
            return StatusCode(201, yeniDuyuru);
        }
    }
}