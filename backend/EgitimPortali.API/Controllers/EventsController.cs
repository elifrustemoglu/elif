using EgitimPortali.API.DTOs;
using EgitimPortali.API.Services;
using EgitimPortali.Core;
using EgitimPortali.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Net; 

namespace EgitimPortali.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<EventListDto>>> GetTumEtkinlikler(
        [FromQuery] string? search,
        [FromQuery] int? categoryId,
        [FromQuery] DateTime? fromDate = null,
        [FromQuery] DateTime? toDate = null,
        [FromQuery] string? sortBy = "date",
        [FromQuery] string? sortOrder = "asc",
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 20)
        {
            var etkinlikler = await _eventService.TumEtkinlikleriGetirAsync(search, categoryId, fromDate, toDate, sortBy, sortOrder, page, pageSize);
            return Ok(etkinlikler);
        }

      
        [HttpGet("{slug}")]
        public async Task<ActionResult<EventDetailDto>> GetEtkinlikBySlug(string slug)
        {
            
            var decodedSlug = WebUtility.UrlDecode(slug).Trim().ToLower();

            var etkinlikDto = await _eventService.SlugIleGetirAsync(decodedSlug);

        
            if (etkinlikDto == null)
            {
                return NotFound(new ProblemDetails
                {
                    Status = 404,
                    Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
                    Title = "Etkinlik Bulunamadı",
                    Detail = $"Sistemde '{decodedSlug}' adresine (slug) sahip bir etkinlik bulunmamaktadır."
                });
            }


            return Ok(etkinlikDto);
        }

        [HttpPost]
        public async Task<ActionResult> EtkinlikOlustur([FromBody] EventCreateDto yeniEtkinlikDto)
        {
            var gercekEtkinlik = new Event
            {
                Title = yeniEtkinlikDto.Title,
                Slug = yeniEtkinlikDto.Slug,
                Description = yeniEtkinlikDto.Description,
                StartDate = yeniEtkinlikDto.StartDate,
                LocationType = yeniEtkinlikDto.LocationType,
                CategoryId = yeniEtkinlikDto.CategoryId
            };

            await _eventService.EtkinlikEkleAsync(gercekEtkinlik);

            return CreatedAtAction(nameof(GetEtkinlikBySlug), new { slug = gercekEtkinlik.Slug }, gercekEtkinlik);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EtkinlikGuncelle(int id, [FromBody] Event guncelVeri)
        {
            if (id != guncelVeri.Id)
            {
                return BadRequest(new ProblemDetails
                {
                    Status = 400,
                    Type = "https://datatracker.ietf.org/doc/html/prettier/rfc7231#section-6.5.1",
                    Title = "Geçersiz İstek (ID Uyuşmazlığı)",
                    Detail = $"URL üzerinden gönderilen ID ({id}) ile gövdedeki etkinlik ID ({guncelVeri.Id}) eşleşmiyor."
                });
            }
            return NoContent();
        }
    }
}