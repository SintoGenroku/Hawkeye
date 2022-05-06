using Hawkeye.OmdbAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hawkeye.OmdbAPI
{
    public class OmdbHttpClient : HttpClient
    {
        public OmdbHttpClient()
        {
            this.BaseAddress = new Uri("https://kinopoiskapiunofficial.tech/api");

        }

        //will work after correct setup API host builder
        /*
                private readonly HttpClient _client;
                private readonly string _apiKey;

                public OmdbHttpClient(HttpClient client, OmdbApiKey apiKey)
                {
                    _client = client;
                    _apiKey = apiKey.Key;
                }
                public async Task<T> GetAsync<T>(string uri)
                {
                    HttpResponseMessage response = await _client.GetAsync($"{uri}?apikey={_apiKey}");
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<T>(jsonResponse);
                }
                */

    }
}
