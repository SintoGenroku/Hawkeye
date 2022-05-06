using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hawkeye.Domain.Models
{
    public class Playlist : DomainObject
    {
        public string Name { get; set; }
        public ICollection<Film> Films { get; set; }
        public User User { get; set; }
    }
}
