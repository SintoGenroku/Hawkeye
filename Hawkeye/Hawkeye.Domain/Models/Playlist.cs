namespace Hawkeye.Domain.Models
{
    public class Playlist : DomainObject
    {
        public string Name { get; set; }
        public ICollection<Film> Films { get; set; }
        public User User { get; set; }
    }
}
