using System.Net.Http.Json;
using System.Text;
using System.Text.Encodings.Web;
using HoyoWiki.Net.Models;
using HoyoWiki.Net.Searches.Models;

namespace HoyoWiki.Net.Searches;

public class SearchClient : ISearchClient
{
    private HttpClient _client;

    public SearchClient(HttpClient client)
    {
        _client = client;
    }
    
    public async Task<IEnumerable<BaseListModel>> GetAsync(string keyword)
    {
        var p = UrlEncoder.Default.Encode(keyword);
        var response = await _client.GetAsync($"./search?keyword={p}");
        var data = (await response.Content.ReadFromJsonAsync<HoyoWikiResponse<SearchListData>>())!;

        if (data.ReturnCode == 0) return data.Data!.List;
        throw new HoyoWikiException("Unable to get search data.", data.ReturnCode);
    }
}