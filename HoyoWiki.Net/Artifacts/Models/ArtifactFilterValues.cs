using System.Text.Json.Serialization;
using HoyoWiki.Net.Models;

namespace HoyoWiki.Net.Artifacts.Models;

public class ArtifactFilterValues
{
    [JsonPropertyName("reliquary_effect")]
    public BaseFiltersModel ReliquaryEffect { get; set; }
}