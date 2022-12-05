using System.Net.Http.Json;
using HoyoWiki.Net.Models;

namespace HoyoWiki.Net;

public interface IPageFilter
{
    public Task UpdateFilterIdsAsync();
    
    protected static async Task<List<MenuFiltersFilter>?> GetFilters(HttpClient client,
        EntryPageMenu menu)
    {
        var response = await client.GetAsync($"./get_menu_filters?menu_id={(int)menu}");
        var data = (await response.Content.ReadFromJsonAsync<HoyoWikiResponse<MenuFiltersData>>())!;
        return data.Data!.GetFiltersAsList();
    }
}