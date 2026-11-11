using System;

namespace EgitimPortali.Core.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }
        public string SenderName { get; set; } = string.Empty;
        public string SenderEmail { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsRead { get; set; } = false;

     
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }

        public ContactMessage() { }

        public ContactMessage(int id, string senderName, string senderEmail, string subject, string message)
        {
            if (string.IsNullOrWhiteSpace(senderName))
                throw new ArgumentException("Gönderici adı boş bırakılamaz.");

            if (string.IsNullOrWhiteSpace(senderEmail) || !senderEmail.Contains('@'))
                throw new ArgumentException("Geçerli bir e-posta adresi giriniz.");

            if (string.IsNullOrWhiteSpace(subject))
                throw new ArgumentException("Konu alanı boş bırakılamaz.");

            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Mesaj içeriği boş bırakılamaz.");

            if (message.Length > 2000)
                throw new ArgumentException("Mesaj 2000 karakterden uzun olamaz.");

            Id = id;
            SenderName = senderName.Trim();
            SenderEmail = senderEmail.Trim();
            Subject = subject.Trim();
            Message = message.Trim();
            CreatedAt = DateTime.UtcNow;
        }
    }
}