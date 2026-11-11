using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using EgitimPortali.API.Services;
using EgitimPortali.API.DTOs;

namespace EgitimPortali.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> KategorileriListele([FromQuery] string? filtreKategori, [FromQuery] bool? aktifMi)
        {
            var kategoriler = await _categoryService.KategorileriListeleAsync(filtreKategori, aktifMi);
            return Ok(kategoriler);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> KategoriEkle([FromBody] CreateCategoryDto yeniKategoriDto)
        {
            var sonuc = await _categoryService.KategoriEkleAsync(yeniKategoriDto);

            if (!sonuc.Basarili)
            {
                if (sonuc.DurumKodu == 400)
                    return BadRequest(sonuc.HataMesaji);

                if (sonuc.DurumKodu == 409)
                    return Conflict(sonuc.HataMesaji);
            }

            return CreatedAtAction(nameof(KategorileriListele), new { id = sonuc.EklenenKategori!.Id }, sonuc.EklenenKategori);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> KategoriSil(int id)
        {
            var silindiMi = await _categoryService.KategoriSilAsync(id);

            if (!silindiMi)
            {
                return NotFound("Kategori bulunamadı veya zaten silinmiş.");
            }

            return NoContent();
        }

        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> KategoriFiltreListesi()
        {
            var kategoriler = await _categoryService.KategoriFiltreListesiAsync();
            return Ok(kategoriler);
        }
    }
}