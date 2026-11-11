using System;

namespace EgitimPortali.Core.Models
{
    public class Announcement
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string PriorityLevel { get; set; } = "Normal";
        public DateTime PublishDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
        public int OrganizerUnitId { get; set; }
        public bool IsPinned { get; set; } = false;
        public bool IsSilent { get; set; } = false;


        public int CategoryId { get; set; }
        public Category? Category { get; set; }


        public Announcement() { }

        public Announcement(int id, string title, string content, int categoryId, string priorityLevel = "Normal")
        {
            if (string.IsNullOrWhiteSpace(title) || title.Trim().Length < 5)
                throw new ArgumentException("Duyuru başlığı en az 5 karakter olmalıdır.");

            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Duyuru içeriği boş bırakılamaz.");

            Id = id;
            Title = title.Trim();
            Content = content.Trim();
            CategoryId = categoryId; 
            PriorityLevel = priorityLevel;
            PublishDate = DateTime.Now;
        }
    }
}