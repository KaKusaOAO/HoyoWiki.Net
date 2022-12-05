using System.Text.Json.Serialization;

namespace HoyoWiki.Net.Models;

public class BaseFiltersModel
{
    [JsonPropertyName("values")]
    public IEnumerable<string> Values { get; set; }
}