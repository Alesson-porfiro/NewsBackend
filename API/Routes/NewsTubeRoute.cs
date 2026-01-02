using GeoIntelligence.Api.Application.Services;

namespace GeoIntelligence.Api.API.Routes
{
    public static class NewsTubeRoute
    {
        public static RouteGroupBuilder MapNewsTubeRoutes(this RouteGroupBuilder group)
        {           
           group.MapGet("/jobs", async (NewsTubeService s) =>
                    Results.Ok(await s.GetBrazilJobsAsync()))
                .WithTags("News - Jobs")
                .WithSummary("Notícias e vagas de emprego")
                .WithDescription("Retorna as principais notícias e vagas de emprego do Brasil.");

            group.MapGet("/sports", async (NewsTubeService s) =>
                    Results.Ok(await s.GetBrazilSportsAsync()))
                .WithTags("News - Sports")
                .WithSummary("Notícias esportivas")
                .WithDescription("Retorna as principais notícias esportivas do Brasil.");

            group.MapGet("/crypto", async (NewsTubeService s) =>
                    Results.Ok(await s.GetBrazilCryptoAsync()))
                .WithTags("News - Crypto")
                .WithSummary("Notícias sobre criptomoedas")
                .WithDescription("Retorna notícias e atualizações sobre criptomoedas no Brasil.");

            group.MapGet("/technology", async (NewsTubeService s) =>
                    Results.Ok(await s.GetBrazilTechnologyAsync()))
                .WithTags("News - Technology")
                .WithSummary("Notícias de tecnologia")
                .WithDescription("Retorna as principais notícias de tecnologia do Brasil.");

            group.MapGet("/entertainment", async (NewsTubeService s) =>
                    Results.Ok(await s.GetBrazilEntertainmentAsync()))
                .WithTags("News - Entertainment")
                .WithSummary("Notícias de entretenimento")
                .WithDescription("Retorna notícias de entretenimento e cultura pop no Brasil.");

            group.MapGet("/entertainment/secondary", async (NewsTubeService s) =>
                    Results.Ok(await s.GetBrazilSecondEntertainmentAsync()))
                .WithTags("News - Entertainment")
                .WithSummary("Notícias secundárias de entretenimento")
                .WithDescription("Retorna notícias secundárias de entretenimento do Brasil.");

            group.MapGet("/policy", async (NewsTubeService s) =>
                    Results.Ok(await s.GetBrazilPolicyAsync()))
                .WithTags("News - Policy")
                .WithSummary("Notícias políticas")
                .WithDescription("Retorna as principais notícias políticas do Brasil.");

            group.MapGet("/crime", async (NewsTubeService s) =>
                    Results.Ok(await s.GetBrazilCrimeAsync()))
                .WithTags("News - Crime")
                .WithSummary("Notícias de crimes e segurança pública")
                .WithDescription("Retorna notícias relacionadas a crimes e segurança pública no Brasil.");

            return group;
        }
    }
}
