using Hawkeye.OmdbAPI.Models;
using Newtonsoft.Json;

namespace Hawkeye.OmdbAPI
{
    public class OmdbHttpClient : HttpClient
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;

        public OmdbHttpClient(HttpClient client, OmdbApiKey apiKey)
        {
            _client = client;
            _client.DefaultRequestHeaders.Add("X-API-KEY", "6f51d678-ae9a-401e-9ed3-6746bda409e6");
            _apiKey = apiKey.Key;
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            HttpResponseMessage response = await _client.GetAsync($"{uri}");
            string jsonResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }
    }
}
