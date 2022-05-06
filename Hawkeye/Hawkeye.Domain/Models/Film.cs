using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hawkeye.Domain.Models
{
    public class Film : DomainObject
    {
        public string Name { get; set; } //+
        public string Genre { get; set; } //+
        public DateTime Date { get; set; } //+
        public double Rate { get; set; } //+
        public string Country { get; set; } //+
        public DateTime Duration { get; set; }//+
        public ICollection<Actor> Actors { get; set; }
        public string Description { get; set; }
        public string shortDescription { get; set; }
        public string Trailer { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Playlist> Playlists { get; set; }
        public string PosterURI { get; set; }
        public string Slogan { get; set; }
    }
}
