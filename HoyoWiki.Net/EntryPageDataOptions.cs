namespace HoyoWiki.Net;

public class EntryPageDataOptions
{
    public int? PageNum { get; set; }
    public int? PageSize { get; set; }
    public IEnumerable<IFilter>? Filters { get; set; }
}