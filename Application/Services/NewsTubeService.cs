using GeoIntelligence.Api.Application.DTOs.Response;
using GeoIntelligence.Api.Domain.Entities;
using GeoIntelligence.Api.Infrastructure.Integrations;

namespace GeoIntelligence.Api.Application.Services
{
    public class NewsTubeService
    {
        private readonly WorldNewsTubeClient _client;

        public NewsTubeService(WorldNewsTubeClient client)
        {
            _client = client;
        }

        private static DateTime ParseDate(string date) =>
            DateTime.TryParse(date, out var parsed) ? parsed : DateTime.UtcNow;

        private static List<NewsTube> MapResponse(
    NewsTubeResponse? response,
    string source)
        {
            if (response?.Results == null || response.Results.Count == 0)
                return new();

            return response.Results.Select(n => new NewsTube
            {
                Title = n.Title,
                Description = n.Description,
                Image = n.Image,
                Url = n.Url,
                Source = source,
                PublishedAt = ParseDate(n.PublishedAt)
            }).ToList();
        }

        public async Task<List<NewsTube>> GetBrazilJobsAsync() =>
            MapResponse(await _client.GetBrazilJobsAsync(), "ApiTube - Jobs BR");

        public async Task<List<NewsTube>> GetBrazilSportsAsync() =>
            MapResponse(await _client.GetBrazilSportsAsync(), "ApiTube - Sports BR");

        public async Task<List<NewsTube>> GetBrazilCryptoAsync() =>
            MapResponse(await _client.GetBrazilCryptoAsync(), "ApiTube - Crypto BR");

        public async Task<List<NewsTube>> GetBrazilTechnologyAsync() =>
            MapResponse(await _client.GetBrazilTechnologyAsync(), "ApiTube - Technology BR");

        public async Task<List<NewsTube>> GetBrazilEntertainmentAsync() =>
            MapResponse(await _client.GetBrazilEntertainmentAsync(), "ApiTube - Entertainment BR");

        public async Task<List<NewsTube>> GetBrazilSecondEntertainmentAsync() =>
            MapResponse(await _client.GetBrazilSecondEntertainmentAsync(), "ApiTube - Entertainment BR");

        public async Task<List<NewsTube>> GetBrazilPolicyAsync() =>
            MapResponse(await _client.GetBrazilPolicyAsync(), "ApiTube - Policy BR");

        public async Task<List<NewsTube>> GetBrazilCrimeAsync() =>
            MapResponse(await _client.GetBrazilNewsAsync(), "ApiTube - Crime BR");
    }
}
