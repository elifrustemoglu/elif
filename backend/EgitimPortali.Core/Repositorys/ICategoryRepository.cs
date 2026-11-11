using System.Collections.Generic;
using System.Threading.Tasks;
using EgitimPortali.Core.Models;

namespace EgitimPortali.Core.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<List<Category>> TumKategorileriGetirAsync();
        Category? GetByName(string name);
        Task<Category?> IdIleGetirAsync(int id);
        void Add(Category category);
        Task AddAsync(Category category);
        Task KategoriEkleAsync(Category yeniKategori);

     
        Task DeleteAsync(int id);
    }
}