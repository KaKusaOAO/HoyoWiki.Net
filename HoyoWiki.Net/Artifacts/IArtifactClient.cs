using HoyoWiki.Net.Artifacts.Models;

namespace HoyoWiki.Net.Artifacts;

public interface IArtifactClient : IEntryPageListData<ArtifactListData, ArtifactList>
{
    public ArtifactFilters Filters { get; }
}