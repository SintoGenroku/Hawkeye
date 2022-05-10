namespace Hawkeye.Domain.Models
{
    public class Role : DomainObject
    {
        public string? Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
