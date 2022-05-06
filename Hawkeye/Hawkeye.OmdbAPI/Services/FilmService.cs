using Hawkeye.OmdbAPI.Models;
using Newtonsoft.Json;

namespace Hawkeye.OmdbAPI.Services
{
    public class FilmService : IFilmDataSourceService
    {
        private readonly OmdbHttpClient _client;

        public FilmService(OmdbHttpClient client)
        {
            _client = client;
        }
        public async Task<FilmDataSource> GetFilmData(int id)
        {
            using(OmdbHttpClient client = new OmdbHttpClient())
            {
                string uri = $"/v2.2/films/{id}";
                HttpResponseMessage response= await client.GetAsync(uri);
                string JsonResponse = await response.Content.ReadAsStringAsync();
                FilmDataSource filmDataSource = JsonConvert.DeserializeObject<FilmDataSource>(JsonResponse);
                return filmDataSource;

            }
        }
    }
}
