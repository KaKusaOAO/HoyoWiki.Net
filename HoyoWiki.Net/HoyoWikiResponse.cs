using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace HoyoWiki.Net;

public class HoyoWikiResponse
{
    [JsonPropertyName("retcode")]
    public int ReturnCode { get; set; }
    
    [JsonPropertyName("message")]
    public string? Message { get; set; }
    
    [JsonPropertyName("data")]
    public JsonNode RawData { get; set; }
}

public class HoyoWikiResponse<T> : HoyoWikiResponse
{
    [JsonIgnore]
    public T? Data
    {
        get => RawData.Deserialize<T>();
        set => RawData = JsonSerializer.SerializeToNode(value)!;
    }
}