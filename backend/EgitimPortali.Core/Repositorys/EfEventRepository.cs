using EgitimPortali.Core;
using EgitimPortali.Core.Models;
using EgitimPortali.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgitimPortali.API.Repositories
{
    public class EfEventRepository : IEventRepository
    {
        private readonly AppDbContext _context;

        public EfEventRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Event?> SlugIleGetirAsync(string slug)
        {
            return await _context.Events
                .Include(e => e.OrganizerUnit)
                .Include(e => e.Category)
                .FirstOrDefaultAsync(e => e.Slug == slug && !e.IsDeleted);
        }

        public async Task<Event?> IdIleGetirAsync(int id)
        {
            return await _context.Events
                .Include(e => e.OrganizerUnit)
                .Include(e => e.Category)
                .FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
        }

        public async Task EtkinlikEkleAsync(Event @event)
        {
            await _context.Events.AddAsync(@event);
            await _context.SaveChangesAsync();
        }

        public async Task<(List<Event> Etkinlikler, int ToplamKayit)> TumEtkinlikleriGetirAsync(
        string? search, int? categoryId, DateTime? fromDate, DateTime? toDate,
        string? sortBy, string? sortOrder, int page, int pageSize)
        {
            var query = _context.Events
                .Include(e => e.Category)
                .Where(e => !e.IsDeleted).AsQueryable();

            int total = await query.CountAsync();

            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return (items, total);
        }
    }
}