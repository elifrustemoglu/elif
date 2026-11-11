using Microsoft.EntityFrameworkCore;
using EgitimPortali.Core.Models;
using System;

namespace EgitimPortali.Core
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<OrganizerUnit> OrganizerUnits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Category>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Event>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Announcement>().HasQueryFilter(a => !a.IsDeleted);
            modelBuilder.Entity<ContactMessage>().HasQueryFilter(cm => !cm.IsDeleted);
            modelBuilder.Entity<OrganizerUnit>().HasQueryFilter(ou => !ou.IsDeleted);

           
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(c => c.Name).IsRequired().HasMaxLength(50);
                entity.HasMany(c => c.Events)
                      .WithOne(e => e.Category)
                      .HasForeignKey(e => e.CategoryId);
            });

            
            modelBuilder.Entity<OrganizerUnit>(entity =>
            {
                entity.ToTable("OrganizerUnits");
                entity.HasKey(ou => ou.Id);
                entity.Property(ou => ou.Name).IsRequired().HasMaxLength(100);

                entity.HasMany(ou => ou.Events)
                      .WithOne(e => e.OrganizerUnit)
                      .HasForeignKey(e => e.OrganizerUnitId);
            });

            
            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Events");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Slug).IsRequired().HasMaxLength(160);
                entity.HasIndex(e => e.Slug).IsUnique();
            });

          
            modelBuilder.Entity<OrganizerUnit>().HasData(
                new OrganizerUnit { Id = 1, Name = "İnsan Kaynakları", IsDeleted = false },
                new OrganizerUnit { Id = 2, Name = "Bilgi Teknolojileri", IsDeleted = false }
            );

        
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Eğitim", IsActive = true, IsDeleted = false },
                new Category { Id = 2, Name = "Seminer", IsActive = true, IsDeleted = false },
                new Category { Id = 3, Name = "Toplantı", IsActive = true, IsDeleted = false }
            );

           
            modelBuilder.Entity<Announcement>().HasData(
                new Announcement { Id = 1, CategoryId = 1, Title = "Yeni Eğitim Portalı Yayında!", Content = "Kurum içi tüm eğitim ve etkinlik kayıtlarını artık bu sistem üzerinden yapabilirsiniz.", IsDeleted = false },
                new Announcement { Id = 2, CategoryId = 1, Title = "C# Kampı Kayıtları Başladı", Content = "Backend yeteneklerinizi geliştirmek için planlanan .NET Bootcamp kayıtlarını kaçırmayın.", IsDeleted = false },
                new Announcement { Id = 3, CategoryId = 1, Title = "Stajyer Sunumları Geri Sayım", Content = "Yıl sonu proje demoları 31 Aralık tarihinde BİM Ana Konferans Salonunda gerçekleştirilecektir.", IsDeleted = false }
            );

            
            modelBuilder.Entity<Event>().HasData(
                new Event { Id = 1, CategoryId = 1, Title = "C# ve .NET Bootcamp", Slug = "csharp-net-bootcamp", Description = "Sıfırdan ileri seviyeye .NET eğitimi.", StartDate = new DateTime(2026, 12, 1, 10, 0, 0, DateTimeKind.Utc), EndDate = new DateTime(2026, 12, 5, 17, 0, 0, DateTimeKind.Utc), LocationType = "Fiziksel", PhysicalAddress = "BİM Ana Konferans Salonu", OrganizerUnitId = 1, Quota = 50, IsDeleted = false },
                new Event { Id = 2, CategoryId = 2, Title = "Veritabanı Optimizasyonu", Slug = "veritabani-optimizasyonu", Description = "EF Core ve MySQL performans ipuçları.", StartDate = new DateTime(2026, 12, 20, 13, 0, 0, DateTimeKind.Utc), EndDate = new DateTime(2026, 12, 20, 15, 0, 0, DateTimeKind.Utc), LocationType = "Online", OnlineMeetingUrl = "https://zoom.us/j/987654", OrganizerUnitId = 1, Quota = null, IsDeleted = false },
                new Event { Id = 3, CategoryId = 1, Title = "Docker Temelleri", Slug = "docker-temelleri", Description = "Konteyner mimarisine giriş.", StartDate = new DateTime(2026, 12, 22, 10, 0, 0, DateTimeKind.Utc), EndDate = new DateTime(2026, 12, 22, 12, 0, 0, DateTimeKind.Utc), LocationType = "Fiziksel", PhysicalAddress = "Eğitim Sınıfı 1", OrganizerUnitId = 1, Quota = 40, IsDeleted = false },
                new Event { Id = 4, CategoryId = 2, Title = "Siber Güvenlik Farkındalığı", Slug = "siber-guvenlik-farkindaligi", Description = "Kurum içi güvenlik kuralları.", StartDate = new DateTime(2026, 12, 28, 14, 0, 0, DateTimeKind.Utc), EndDate = new DateTime(2026, 12, 28, 16, 0, 0, DateTimeKind.Utc), LocationType = "Online", OnlineMeetingUrl = "https://zoom.us/j/112233", OrganizerUnitId = 2, Quota = 500, IsDeleted = false },
                new Event { Id = 5, CategoryId = 3, Title = "Stajyer Proje Sunumları", Slug = "stajyer-proje-sunumlari", Description = "Stajyerlerin geliştirdiği Eğitim Portalı demosu.", StartDate = new DateTime(2026, 12, 31, 10, 0, 0, DateTimeKind.Utc), EndDate = new DateTime(2026, 12, 31, 14, 0, 0, DateTimeKind.Utc), LocationType = "Fiziksel", PhysicalAddress = "BİM Ana Konferans Salonu", OrganizerUnitId = 1, Quota = 150, IsDeleted = false }
            );
        }
    }
}