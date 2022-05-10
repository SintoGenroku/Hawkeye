namespace Hawkeye.Domain.Models
{
    public class User : DomainObject
    {
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<Playlist> Playlists { get; set; }
        public Role Role { get; set; }
    }
}
