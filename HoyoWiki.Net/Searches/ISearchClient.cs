using HoyoWiki.Net.Models;
using HoyoWiki.Net.Searches.Models;

namespace HoyoWiki.Net.Searches;

public interface ISearchClient
{
    public Task<IEnumerable<BaseListModel>> GetAsync(string keyword);
}