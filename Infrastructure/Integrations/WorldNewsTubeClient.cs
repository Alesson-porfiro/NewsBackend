using System.Net.Http.Json;
using GeoIntelligence.Api.Application.DTOs.Response;

namespace GeoIntelligence.Api.Infrastructure.Integrations
{
    public class WorldNewsTubeClient
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _config;

        public WorldNewsTubeClient(HttpClient http, IConfiguration config)
        {
            _http = http;
            _config = config;
            _http.BaseAddress = new Uri("https://api.apitube.io/v1/news/");
        }

        private async Task<NewsTubeResponse?> GetLatestAsync(string categoryId)
        {
            var apiKey = _config["WorldNewsTube:ApiKey"];

            var url =
                $"everything?api_key={apiKey}" +
                $"&source.country.code=br" +
                $"&category.id={categoryId}";

            var response = await _http.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<NewsTubeResponse>();
        }

        // 🔹 Policia/Mortes    
        public Task<NewsTubeResponse?> GetBrazilNewsAsync() =>
            GetLatestAsync("medtop:20000133"); 

        // 🔹 Trabalhos
        public Task<NewsTubeResponse?> GetBrazilJobsAsync() =>
            GetLatestAsync("medtop:20000276"); 

         // 🔹 Cultura/Entreterimento     
        public Task<NewsTubeResponse?> GetBrazilEntertainmentAsync() =>
            GetLatestAsync("medtop:01000000"); 

        // 🔹 Segundo Cultura/Entreterimento     
        public Task<NewsTubeResponse?> GetBrazilSecondEntertainmentAsync() =>
            GetLatestAsync("medtop:20000002"); 

         // 🔹 Esportes 
        public Task<NewsTubeResponse?> GetBrazilSportsAsync() =>
            GetLatestAsync("medtop:20001108");

        // 🔹 Crypto Brasil
        public Task<NewsTubeResponse?> GetBrazilCryptoAsync() =>
            GetLatestAsync("medtop:20001279");

        // 🔹 Tecnologia
        public Task<NewsTubeResponse?> GetBrazilTechnologyAsync() =>
            GetLatestAsync("medtop:20000736");

        // 🔹 Politica   
        public Task<NewsTubeResponse?> GetBrazilPolicyAsync() =>
            GetLatestAsync("medtop:20000065"); 
    }
}
