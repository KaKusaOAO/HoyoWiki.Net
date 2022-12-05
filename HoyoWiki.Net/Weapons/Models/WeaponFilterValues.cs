using System.Text.Json.Serialization;
using HoyoWiki.Net.Models;

namespace HoyoWiki.Net.Weapons.Models;

public class WeaponFilterValues
{
    [JsonPropertyName("weapon_type")]
    public BaseFiltersModel Type { get; set; }
    
    [JsonPropertyName("weapon_property")]
    public BaseFiltersModel Property { get; set; }
    
    [JsonPropertyName("weapon_rarity")]
    public BaseFiltersModel Rarity { get; set; }
}