using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EgitimPortali.Core.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }

        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}