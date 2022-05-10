namespace Hawkeye.Domain.Models
{
    public class Actor : DomainObject
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Nation { get; set; }
        public ICollection<Film> Films { get; set; }

    }
}
