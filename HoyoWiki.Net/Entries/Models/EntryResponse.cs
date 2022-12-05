using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace HoyoWiki.Net.Entries.Models;

public class EntryPage
{
    [JsonPropertyName("page")]
    public JsonObject Page { get; set; }
    
    public T? As<T>() where T : AbstractPage => Page.Deserialize<T>();
}