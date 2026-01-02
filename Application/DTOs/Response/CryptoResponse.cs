using System.Text.Json.Serialization;

namespace GeoIntelligence.Api.Application.DTOs.Response
{
    public class CryptoResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("image")]
        public string Image { get; set; } = string.Empty;

        [JsonPropertyName("current_price")]
        public decimal CurrentPrice { get; set; }

        [JsonPropertyName("market_cap")]
        public decimal MarketCap { get; set; }

        [JsonPropertyName("total_volume")]
        public decimal TotalVolume { get; set; }

        [JsonPropertyName("price_change_percentage_24h")]
        public decimal Change24h { get; set; }
    }
}
