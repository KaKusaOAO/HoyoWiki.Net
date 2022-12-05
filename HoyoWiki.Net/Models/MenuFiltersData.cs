using System.Text.Json.Serialization;

namespace HoyoWiki.Net.Models;

public class MenuFiltersValue
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    
    [JsonPropertyName("value")]
    public string Value { get; set; }
}

public class MenuFiltersFilter
{
    [JsonPropertyName("key")]
    public string Key { get; set; }
    
    [JsonPropertyName("text")]
    public string Text { get; set; }
    
    [JsonPropertyName("values")]
    public IEnumerable<MenuFiltersValue>? Values { get; set; }

    public List<MenuFiltersValue>? GetValuesAsList() => Values?.ToList();
}

public class MenuFiltersData
{
    [JsonPropertyName("filters")]
    public IEnumerable<MenuFiltersFilter>? Filters { get; set; }
    
    public List<MenuFiltersFilter>? GetFiltersAsList() => Filters?.ToList();
}