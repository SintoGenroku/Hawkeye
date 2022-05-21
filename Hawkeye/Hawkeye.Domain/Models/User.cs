
using System.ComponentModel.DataAnnotations.Schema;

namespace Hawkeye.Domain.Models
{
    public class User : DomainObject
    {
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<Playlist> Playlists { get; set; }
        public ICollection<Film> FavoriteFilms { get; set; }
        public Role Role { get; set; }
        public Guid RoleId { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
