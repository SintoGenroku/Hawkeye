using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hawkeye.OmdbAPI.Models
{
    public class OmdbApiKey
    {
        public string Key { get; }
        public OmdbApiKey(string key)
        {
            Key = key;
        }
    }
}
