using System.Text.Json.Serialization;

namespace HoyoWiki.Net.Models;

public class BaseListDataModel
{
    [JsonPropertyName("total")]
    public string Total { get; set; }
}

public class BaseListDataModel<T> : BaseListDataModel
{
    [JsonPropertyName("list")]
    public IEnumerable<T> List { get; set; }
}