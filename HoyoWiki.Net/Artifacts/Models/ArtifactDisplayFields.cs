using System.Text.Json.Serialization;

namespace HoyoWiki.Net.Artifacts.Models;

public class ArtifactDisplayFields
{
    [JsonPropertyName("goblet_of_eonothem_icon_url")]
    public string GobletOfEonothemIconUrl { get; set; }
    
    [JsonPropertyName("flower_of_life_icon_url")]
    public string FlowerOfLifeIconUrl { get; set; }
    
    [JsonPropertyName("circlet_of_logos_icon_url")]
    public string CircletOfLogosIconUrl { get; set; }
    
    [JsonPropertyName("sands_of_eon_icon_url")]
    public string SandsOfEonIconUrl { get; set; }
    
    [JsonPropertyName("plume_of_death_icon_url")]
    public string PlumeOfDeathIconUrl { get; set; }
    
    [JsonPropertyName("four_set_effect")]
    public string FourSetEffect { get; set; }
    
    [JsonPropertyName("two_set_effect")]
    public string TwoSetEffect { get; set; }
    
    [JsonPropertyName("single_set_effect")]
    public string SingleSetEffect { get; set; }
}