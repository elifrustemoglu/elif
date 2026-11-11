using System.Collections.Generic;
using System.Threading.Tasks;
using EgitimPortali.API.DTOs;

namespace EgitimPortali.API.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> KategorileriListeleAsync(string? filtreKategori, bool? aktifMi);
        Task<(bool Basarili, int DurumKodu, string? HataMesaji, CategoryDto? EklenenKategori)> KategoriEkleAsync(CreateCategoryDto yeniKategoriDto);
        Task<bool> KategoriSilAsync(int id);
        Task<List<CategoryListDto>> KategoriFiltreListesiAsync();
    }
}