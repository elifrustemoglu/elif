namespace EgitimPortali.Core.Models
{
    public class OrganizerUnit
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}