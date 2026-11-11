using System;

namespace EgitimPortali.Core.Models
{
    public class Event
    {
        public int Id { get; set; }

        private string _title = string.Empty;
        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hata: Etkinlik başlığı boş bırakılmamalıdır.");
                }
                _title = value;
            }
        }

        public string Slug { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        private DateTime _startDate;
        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                
                if (value < DateTime.UtcNow)
                {
                    throw new ArgumentException("Hata: Etkinlik tarihi geçmiş bir zaman olmamalıdır.");
                }
                _startDate = value;
            }
        }

        public DateTime EndDate { get; set; }
        public string LocationType { get; set; } = string.Empty;

        public int CategoryId { get; set; }
        public int OrganizerUnitId { get; set; }

        public string? PhysicalAddress { get; set; }
        public string? OnlineMeetingUrl { get; set; }

        private int? _quota;
        public int? Quota
        {
            get => _quota;
            set
            {
                if (value.HasValue && value.Value <= 0)
                {
                    throw new ArgumentException("Hata: Kontenjan belirtilecekse 0'dan büyük olmalıdır. Sınırsız ise boş (null) bırakın.");
                }
                _quota = value;
            }
        }

       
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }

       
        public Category? Category { get; set; }

        
        public OrganizerUnit? OrganizerUnit { get; set; }
    }
}