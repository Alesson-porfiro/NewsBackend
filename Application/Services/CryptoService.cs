using GeoIntelligence.Api.Application.DTOs.Response;

public class CryptoService
{
    private readonly CryptoClient _client;

    public CryptoService(CryptoClient client)
    {
        _client = client;
    }

    public async Task<List<CryptoResponse>> GetCryptoAsync()
    {
        return await _client.GetCryptosAsync();
    }
}
