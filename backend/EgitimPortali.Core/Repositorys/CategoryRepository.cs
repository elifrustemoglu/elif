using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EgitimPortali.Core.Models;
using EgitimPortali.Core;

namespace EgitimPortali.Core.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
        }

        public async Task<List<Category>> TumKategorileriGetirAsync()
        {
            return await GetAllAsync();
        }

        public Category? GetByName(string name)
        {
            return _context.Categories.FirstOrDefault(c => c.Name.ToLower() == name.ToLower() && !c.IsDeleted);
        }

        public async Task<Category?> IdIleGetirAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task KategoriEkleAsync(Category yeniKategori)
        {
            await AddAsync(yeniKategori);
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                category.IsDeleted = true;
                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}