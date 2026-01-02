using System.Net.Http.Json;
using GeoIntelligence.Api.Application.DTOs.Response;

public class CryptoClient
{
    private readonly HttpClient _http;
    private readonly IConfiguration _config;

    public CryptoClient(HttpClient http, IConfiguration config)
    {
        _http = http;
        _config = config;

        _http.BaseAddress = new Uri("https://api.coingecko.com/api/v3/");

        _http.DefaultRequestHeaders.UserAgent.ParseAdd(
            "GeoIntelligence/1.0"
        );

        _http.DefaultRequestHeaders.Add(
            "x-cg-demo-api-key",
            _config["Crypto:ApiKey"]
        );
    }

    public async Task<List<CryptoResponse>> GetCryptosAsync()
    {
        var url =
            "coins/markets?vs_currency=brl&ids=bitcoin,ethereum,tether,solana,tron,cardano,dogecoin,zcash,usds";

        var response = await _http.GetAsync(url);

        response.EnsureSuccessStatusCode();

        return await response.Content
            .ReadFromJsonAsync<List<CryptoResponse>>()
            ?? new List<CryptoResponse>();
    }
}
