using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EgitimPortali.Core.Repositories;
using EgitimPortali.Core.Models;

namespace EgitimPortali.Core
{
    public class InMemoryCategoryRepository : ICategoryRepository
    {
        private readonly List<Category> _categories = new()
        {
            new Category { Id = 1, Name = "Eğitim", IsActive = true, IsDeleted = false },
            new Category { Id = 2, Name = "Sosyal", IsActive = true, IsDeleted = false },
            new Category { Id = 3, Name = "Kültür", IsActive = false, IsDeleted = false }
        };

        public async Task<List<Category>> GetAllAsync()
        {
            await Task.Delay(100);
            return _categories.Where(c => !c.IsDeleted).ToList();
        }

        public async Task<List<Category>> TumKategorileriGetirAsync() => await GetAllAsync();

        public Category? GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return null;

            return _categories.FirstOrDefault(c =>
                c.Name.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase) && !c.IsDeleted);
        }

        public async Task<Category?> IdIleGetirAsync(int id)
        {
            await Task.Delay(50);
            return _categories.FirstOrDefault(c => c.Id == id && !c.IsDeleted);
        }

        public void Add(Category category)
        {
            ArgumentNullException.ThrowIfNull(category);

            if (category.Id <= 0)
            {
                category.Id = _categories.Any() ? _categories.Max(c => c.Id) + 1 : 1;
            }

            _categories.Add(category);
        }

        public async Task AddAsync(Category category)
        {
            await Task.Delay(50);
            Add(category);
        }

        public async Task KategoriEkleAsync(Category yeniKategori) => await AddAsync(yeniKategori);


        public Task DeleteAsync(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                category.IsDeleted = true;
            }
            return Task.CompletedTask;
        }
    }
}