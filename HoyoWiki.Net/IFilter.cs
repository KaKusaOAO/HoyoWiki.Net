namespace HoyoWiki.Net;

public interface IFilter
{
    internal string ApiFilter { get; }
}

public class Filter : IFilter
{
    public int DefaultId { get; }
    internal int? OverrideId { get; set; }
    public int Id => OverrideId ?? DefaultId;

    public Filter(int defaultId = 0)
    {
        DefaultId = defaultId;
    }

    public string ApiFilter => Id.ToString();
}