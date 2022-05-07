using Newtonsoft.Json;

namespace Hawkeye.OmdbAPI
{
    public class OmdbHttpClient : HttpClient
    {
        private readonly HttpClient _httpClient;
        private const string key = "6f51d678-ae9a-401e-9ed3-6746bda409e6";
        public OmdbHttpClient()
        {
            this.BaseAddress = new Uri("https://kinopoiskapiunofficial.tech/api");
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("X-API-KEY", key);
        }

        public async Task<T> GetAsync<T>(string uri)
        {
/*            
            var response = await _httpClient.GetAsync("https://kinopoiskapiunofficial.tech/api/v2.2/films/435"); //$"{BaseAddress}{uri}"

            response.EnsureSuccessStatusCode();*/
            /*HttpResponseMessage response = new HttpResponseMessage();
            response.TrailingHeaders.Add("X-API_KEY", "6f51d678-ae9a-401e-9ed3-6746bda409e6");*/
            HttpResponseMessage response = await _httpClient.GetAsync($"{BaseAddress}{uri}?apikey={key}"); //{_apiKey}
            string jsonResponse = await response.Content.ReadAsStringAsync();
            
            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }
    }
}
