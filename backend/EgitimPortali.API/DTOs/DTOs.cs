using System;
using System.ComponentModel.DataAnnotations;

namespace EgitimPortali.API.DTOs
{
    public class EventCreateDto
    {
        [Required(ErrorMessage = "Etkinlik başlığı zorunludur.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Başlık 3 ile 100 karakter arasında olmalıdır.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "URL için kullanılacak Slug alanı zorunludur.")]
        public string Slug { get; set; } = string.Empty;

        [Required(ErrorMessage = "Açıklama alanı zorunludur.")]
        [MaxLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Başlangıç tarihi zorunludur.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Konum türü belirtilmelidir (Online veya Yüz Yüze).")]
        public string LocationType { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir Kategori ID numarası girilmelidir.")]
        public int CategoryId { get; set; }
    }

    public class EventDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string LocationType { get; set; } = string.Empty;
        public int Quota { get; set; }
        public string? OrganizerUnitName { get; set; }
    }

    public class EventListDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? OrganizerUnitName { get; set; }
    }

    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }

    public class CreateCategoryDto
    {
        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Kategori adı 2 ile 50 karakter arasında olmalıdır.")]
        public string Name { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
    }

    public class AnnouncementDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }

    public class CreateAnnouncementDto
    {
        [Required(ErrorMessage = "Duyuru başlığı zorunludur.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Başlık 3 ile 150 karakter arasında olmalıdır.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Duyuru içeriği zorunludur.")]
        [MinLength(10, ErrorMessage = "Duyuru içeriği en az 10 karakter olmalıdır.")]
        public string Content { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
    }

    public class ContactMessageDto
    {
        public int Id { get; set; }
        public string SenderName { get; set; } = string.Empty;
        public string SenderEmail { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }
    }

    public class CreateContactMessageDto
    {
        [Required(ErrorMessage = "Gönderici adı zorunludur.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Gönderici adı 2-100 karakter arasında olmalıdır.")]
        public string SenderName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email alanı zorunludur.")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string SenderEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Konu alanı zorunludur.")]
        [MaxLength(150, ErrorMessage = "Konu en fazla 150 karakter olabilir.")]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mesaj alanı zorunludur.")]
        [MinLength(10, ErrorMessage = "Mesaj alanı en az 10 karakter olmalıdır.")]
        [MaxLength(2000, ErrorMessage = "Mesaj alanı en fazla 2000 karakter olabilir.")]
        public string Message { get; set; } = string.Empty;
    }

    public class CategoryListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}