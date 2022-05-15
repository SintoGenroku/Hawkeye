using Hawkeye.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hawkeye.WPF.Models
{
    public class UserComment
    {
        public Guid UserID { get; set; }
        public string Username { get; set; }
        public Guid FilmID { get; set; }
        public string CommentText { get; set; }
        public Film Film { get; set; }
    }
}
