using System.Net.Http.Json;
using System.Text.Json.Nodes;
using HoyoWiki.Net.Entries.Models;

namespace HoyoWiki.Net.Entries;

public class EntryClient : IEntryClient
{
    private HttpClient _client;

    public EntryClient(HttpClient client)
    {
        _client = client;
    }
    
    public async Task<JsonObject> GetAsync(int id)
    {
        var response = await _client.GetAsync($"./entry_page?entry_page_id={id}");
        var data = (await response.Content.ReadFromJsonAsync<HoyoWikiResponse<EntryPage>>())!;

        if (data.ReturnCode == 404) throw new HoyoWikiException($"Entry ID {id} is invalid.", data.ReturnCode);
        if (data.ReturnCode == 0) return data.Data!.Page;

        throw new HoyoWikiException($"Unable to get data, entry id: {id}", data.ReturnCode);
    }
}