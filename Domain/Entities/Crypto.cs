namespace GeoIntelligence.Api.Domain.Entities
{
    public class Crypto
    {
        public string Name { get; set; } = string.Empty;
        public decimal PriceBrl { get; set; }
        public decimal Change24h { get; set; }
    }
}
