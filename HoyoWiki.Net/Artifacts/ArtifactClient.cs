using HoyoWiki.Net.Artifacts.Models;

namespace HoyoWiki.Net.Artifacts;

public class ArtifactClient : BaseEntryPageClient<ArtifactListData, ArtifactList>, IArtifactClient
{
    public ArtifactClient(HttpClient client)
    {
        HttpClient = client;
        Filters = new ArtifactFilters(client);
    }
    
    public ArtifactFilters Filters { get; }
    protected override HttpClient HttpClient { get; }
    protected override EntryPageMenu Menu => EntryPageMenu.Artifact;
}