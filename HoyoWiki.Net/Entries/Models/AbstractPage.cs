using System.Text.Json.Serialization;
using HoyoWiki.Net.Characters.Models;

namespace HoyoWiki.Net.Entries.Models;

public abstract class AbstractPage
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("desc")]
    public string Description { get; set; }
    
    [JsonPropertyName("icon_url")]
    public string IconUrl { get; set; }
    
    [JsonPropertyName("header_img_url")]
    public string HeaderImageUrl { get; set; }
    
    [JsonPropertyName("modules")]
    public IEnumerable<EntryModule> Modules { get; set; }
    
    [JsonPropertyName("menu_id")]
    public string MenuId { get; set; }
    
    [JsonPropertyName("menu_name")]
    public string MenuName { get; set; }
    
    [JsonPropertyName("version")]
    public string Version { get; set; }
    
    [JsonPropertyName("langs")]
    public IEnumerable<string> Languages { get; set; }
}

public abstract class AbstractPage<T> : AbstractPage
{
    [JsonPropertyName("filter_values")]
    public CharacterFilterValues FilterValues { get; set; }
}