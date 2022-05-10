namespace Hawkeye.Domain.Models
{
    public class Comment : DomainObject
    {
        public Guid UserID { get; set; }
        public Guid FilmID { get; set; }
        public string CommentText { get; set; }
        public Film Film { get; set; }
    }
}
