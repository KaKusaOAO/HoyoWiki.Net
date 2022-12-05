namespace HoyoWiki.Net;

public interface IEntryPageListData
{
    public Task<int> GetTotalAsync(params IFilter[] filters);
}

public interface IEntryPageListData<TItem, TList> : IEntryPageListData
{
    public Task<TItem> GetAsync(EntryPageDataOptions? options = null);
    public Task<IEnumerable<TList>> GetListAsync(params IFilter[] filters);
    public Task<IEnumerable<TList>> SearchListByNameAsync(string name);
}