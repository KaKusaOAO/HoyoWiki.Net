using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using HoyoWiki.Net.Characters.Models;

namespace HoyoWiki.Net.Models;

public class BaseListModel
{
    [JsonPropertyName("entry_page_id")]
    public string EntryPageId { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("icon_url")]
    public string IconUrl { get; set; }
}

public class BaseListModel<TFields, TFilterValues> : BaseListModel
{
    [JsonPropertyName("display_field")]
    public TFields DisplayField { get; set; }
    
    [JsonPropertyName("filter_values")]
    public TFilterValues FilterValues { get; set; }
}