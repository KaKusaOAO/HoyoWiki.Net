using System.Net.Http.Json;
using HoyoWiki.Net.Models;

namespace HoyoWiki.Net;

public abstract class BaseEntryPageClient<TData, TList> : IEntryPageListData<TData, TList>
    where TList : BaseListModel
    where TData : BaseListDataModel<TList>
{
    protected abstract HttpClient HttpClient { get; }
    protected abstract EntryPageMenu Menu { get; }

    public async Task<TData> GetAsync(EntryPageDataOptions? options = null)
    {
        var response = await HttpClient.PostAsJsonAsync("./get_entry_page_list", new EntryRequest
        {
            Filters = options?.Filters?.Select(f => f.ApiFilter) ?? ArraySegment<string>.Empty,
            MenuId = ((int)Menu).ToString(),
            PageNum = options?.PageNum ?? 1,
            PageSize = options?.PageSize ?? 30,
            UseEs = true
        });

        var data = (await response.Content.ReadFromJsonAsync<HoyoWikiResponse<TData>>())!;
        if (data.ReturnCode == 0) return data.Data!;

        throw new HoyoWikiException(data.Message ?? $"Unable to get {Menu} data.", data.ReturnCode);
    }
    
    private async Task<IEnumerable<TList>> GetListConcatAsync(EntryPageDataOptions? options = null)
    {
        var data = await GetAsync(options);
        var list = data.List.ToList();
        if (!list.Any()) return ArraySegment<TList>.Empty;

        var dataNext = await GetListConcatAsync(new EntryPageDataOptions()
        {
            PageNum = options?.PageNum != null ? options.PageNum + 1 : 2,
            PageSize = options?.PageSize ?? 30,
            Filters = options?.Filters ?? Array.Empty<IFilter>()
        });

        return list.Concat(dataNext);
    }

    public Task<IEnumerable<TList>> GetListAsync(params IFilter[] filters)
    {
        return GetListConcatAsync(new EntryPageDataOptions
        {
            Filters = filters
        });
    }
    
    public async Task<int> GetTotalAsync(params IFilter[] filters)
    {
        var data = await GetAsync(new EntryPageDataOptions
        {
            PageNum = 1,
            PageSize = 0,
            Filters = filters
        });

        return int.Parse(data.Total);
    }

    public async Task<IEnumerable<TList>> SearchListByNameAsync(string name)
    {
        var data = await GetListAsync();
        return data.Where(i => i.Name == name);
    }
}