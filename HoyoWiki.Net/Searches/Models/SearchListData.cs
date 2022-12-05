using System.Text.Json.Serialization;
using HoyoWiki.Net.Models;

namespace HoyoWiki.Net.Searches.Models;

public class SearchListData
{
    [JsonPropertyName("list")]
    public IEnumerable<BaseListModel> List { get; set; }
}