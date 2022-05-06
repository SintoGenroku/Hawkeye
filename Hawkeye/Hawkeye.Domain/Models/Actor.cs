using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
