using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EgitimPortali.Core.Repositories;
using EgitimPortali.Core;
using EgitimPortali.Core.Models;
using EgitimPortali.API.DTOs;

namespace EgitimPortali.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryDto>> KategorileriListeleAsync(string? filtreKategori, bool? aktifMi)
        {
            var kategoriListesi = await _categoryRepository.GetAllAsync();

            
            IEnumerable<Category> filtrelenmis = kategoriListesi.Where(c => !c.IsDeleted);

            if (!string.IsNullOrWhiteSpace(filtreKategori))
            {
                filtrelenmis = filtrelenmis.Where(c => c.Name.Contains(filtreKategori.Trim(), StringComparison.OrdinalIgnoreCase));
            }

            if (aktifMi.HasValue)
            {
                filtrelenmis = filtrelenmis.Where(c => c.IsActive == aktifMi.Value);
            }

            return filtrelenmis.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                IsActive = c.IsActive
            }).ToList();
        }

        public async Task<(bool Basarili, int DurumKodu, string? HataMesaji, CategoryDto? EklenenKategori)> KategoriEkleAsync(CreateCategoryDto yeniKategoriDto)
        {
            if (yeniKategoriDto == null || string.IsNullOrWhiteSpace(yeniKategoriDto.Name))
            {
                return (false, 400, "Kategori adı boş bırakılamaz.", null);
            }

            var mevcutKategori = _categoryRepository.GetByName(yeniKategoriDto.Name.Trim());
            if (mevcutKategori != null && !mevcutKategori.IsDeleted)
            {
                return (false, 409, "Bu isimde bir kategori zaten mevcut.", null);
            }

            var yeniKategori = new Category
            {
                Name = yeniKategoriDto.Name.Trim(),
                IsActive = yeniKategoriDto.IsActive,
                IsDeleted = false
            };

            await _categoryRepository.AddAsync(yeniKategori);

            var sonucDto = new CategoryDto
            {
                Id = yeniKategori.Id,
                Name = yeniKategori.Name,
                IsActive = yeniKategori.IsActive
            };

            return (true, 201, null, sonucDto);
        }

        public async Task<bool> KategoriSilAsync(int id)
        {
            var kategori = await _categoryRepository.IdIleGetirAsync(id);

            if (kategori == null)
            {
                return false;
            }

            await _categoryRepository.DeleteAsync(id);
            return true;
        }

        public async Task<List<CategoryListDto>> KategoriFiltreListesiAsync()
        {
            var kategoriler = await _categoryRepository.GetAllAsync();

            return kategoriler
                .Where(c => !c.IsDeleted && c.IsActive)
                .Select(c => new CategoryListDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .OrderBy(c => c.Name)
                .ToList();
        }
    }
}