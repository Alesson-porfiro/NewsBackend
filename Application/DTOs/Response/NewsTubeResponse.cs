using System.Text.Json.Serialization;

namespace GeoIntelligence.Api.Application.DTOs.Response;

public class NewsTubeResponse
{
    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("limit")]
    public int Limit { get; set; }

    [JsonPropertyName("page")]
    public int Page { get; set; }

    [JsonPropertyName("results")]
    public List<NewsTubeItemDto> Results { get; set; } = new();
}

public class NewsTubeItemDto
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("body")]
    public string Body { get; set; } = string.Empty;

    [JsonPropertyName("Image")]
    public string Image {get; set;} = string.Empty;

    [JsonPropertyName("href")]
    public string Url { get; set; } = string.Empty;

    [JsonPropertyName("published_at")]
    public string PublishedAt { get; set; } = string.Empty;

    [JsonPropertyName("language")]
    public string Language { get; set; } = string.Empty;
}
