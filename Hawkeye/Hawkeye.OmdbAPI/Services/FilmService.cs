using Hawkeye.OmdbAPI.Models;
using Newtonsoft.Json;

namespace Hawkeye.OmdbAPI.Services
{
    public class FilmService : IFilmService
    {
        private readonly OmdbHttpClient _client;


        public FilmService(OmdbHttpClient client)
        {
            _client = client;
        }
        public async Task<FilmDataSource> GetFilmData(int id)
        {
            /*using(OmdbHttpClient client = new OmdbHttpClient())
            {*/
                string uri = $"/v2.2/films/{id}";
                FilmDataSource filmDataSource= await _client.GetAsync<FilmDataSource>(uri);
                if(filmDataSource == null)
                {
                    throw new Exception("Фильма такого няма");
                }
                //throw new Exception("!!!\n"+filmDataSource.Description);
                return filmDataSource;

            //}
        }
    }
}
