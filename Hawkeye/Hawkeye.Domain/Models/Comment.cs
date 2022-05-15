namespace Hawkeye.Domain.Models
{
    public class Comment : DomainObject
    {
        public User User { get; set; }
        public Guid FilmID { get; set; }
        public string CommentText { get; set; }
        public Film Film { get; set; }
    }
}
