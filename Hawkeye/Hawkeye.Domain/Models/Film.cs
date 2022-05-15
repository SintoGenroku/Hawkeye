namespace Hawkeye.Domain.Models
{
    public class Film : DomainObject
    {
        public string Name { get; set; } 
        public string Genre { get; set; } 
        public int Year { get; set; } 
        public double Rate { get; set; } 
        public string Country { get; set; } 
        public string Duration { get; set; }
        public string? Description { get; set; }
        public string? shortDescription { get; set; }
        public string? Trailer { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Playlist>? Playlists { get; set; }
        public ICollection<User>? LikedUsers { get; set; }
        public string? PosterURI { get; set; }
        public string? Slogan { get; set; }
    }
}
