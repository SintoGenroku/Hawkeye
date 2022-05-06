using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hawkeye.Domain.Models
{
    public class User : DomainObject
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public ICollection<Playlist> Playlists { get; set; }
        public Role Role { get; set; }
    }
}
