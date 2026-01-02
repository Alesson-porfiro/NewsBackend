using GeoIntelligence.Api.Application.Services;

namespace GeoIntelligence.Api.API.Routes;

public static class CryptoRoutes
{
    public static RouteGroupBuilder MapNewsCryptoRoutes(this RouteGroupBuilder group)
    {
        group.MapGet("/crypto", async (CryptoService s) =>
            Results.Ok(await s.GetCryptoAsync()))
            .WithTags("News - Crypto")
            .WithSummary("Preços sobre criptomoedas")
            .WithDescription("Retorna os preços atualizados e variações de criptomoedas.");

        return group;
    }
}
