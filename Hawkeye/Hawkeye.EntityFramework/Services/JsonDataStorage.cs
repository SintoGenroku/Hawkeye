using Hawkeye.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Hawkeye.EntityFramework.Services
{
    public static class JsonDataStorage
    {
        private static readonly string _path = @"Hawkeye.FilmsStorage.json";

        public static List<Film> GetFilmsData()
        {
            string data;
            using(var fstream = new StreamReader(_path))
            {
                data = fstream.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<Film>>(data);
        }
    }
}
