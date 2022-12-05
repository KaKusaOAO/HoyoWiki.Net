using HoyoWiki.Net.Artifacts;
using HoyoWiki.Net.Characters;
using HoyoWiki.Net.Enemies;
using HoyoWiki.Net.Entries;
using HoyoWiki.Net.Searches;
using HoyoWiki.Net.Weapons;

namespace HoyoWiki.Net;

public interface IHoyoWikiClient
{
    public Language Language { get; }
    
    public ICharacterClient Character { get; }
    public IWeaponClient Weapon { get; }
    public IArtifactClient Artifact { get; }
    // public IEnemyClient Enemy { get; }
    public IEntryClient Entry { get; }
    
    public ISearchClient Search { get; }

    public Task SetLanguageAsync(Language language);
}

