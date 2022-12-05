using System.Text.Json.Serialization;
using HoyoWiki.Net.Models;

namespace HoyoWiki.Net.Characters.Models;

public class CharacterFilterValues
{
    [JsonPropertyName("character_region")]
    public BaseFiltersModel Region { get; set; }
    
    [JsonPropertyName("character_weapon")]
    public BaseFiltersModel Weapon { get; set; }
    
    [JsonPropertyName("character_rarity")]
    public BaseFiltersModel Rarity { get; set; }
    
    [JsonPropertyName("character_property")]
    public BaseFiltersModel Property { get; set; }
    
    [JsonPropertyName("character_vision")]
    public BaseFiltersModel Vision { get; set; }
}