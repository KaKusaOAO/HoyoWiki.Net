using System.Text.Json.Serialization;

namespace HoyoWiki.Net.Models;

public class EntryRequest
{
    [JsonPropertyName("filters")]
    public IEnumerable<string> Filters { get; set; }
    
    [JsonPropertyName("menu_id")]
    public string MenuId { get; set; }
    
    [JsonPropertyName("page_num")]
    public int PageNum { get; set; }
    
    [JsonPropertyName("page_size")]
    public int PageSize { get; set; }
    
    [JsonPropertyName("use_es")]
    public bool UseEs { get; set; }

    public EntryRequest SetMenuId(EntryPageMenu menu)
    {
        MenuId = ((int)menu).ToString();
        return this;
    }
}