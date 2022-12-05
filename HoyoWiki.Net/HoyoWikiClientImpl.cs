using System.Net.Http.Headers;
using HoyoWiki.Net.Artifacts;
using HoyoWiki.Net.Characters;
using HoyoWiki.Net.Entries;
using HoyoWiki.Net.Searches;
using HoyoWiki.Net.Weapons;

namespace HoyoWiki.Net;

internal class HoyoWikiClientImpl : IHoyoWikiClient
{
    public Language Language { get; private set; }
    private readonly HttpClient _client = new();
    
    public CharacterClient Character { get; }
    public WeaponClient Weapon { get; }
    public ArtifactClient Artifact { get; }
    public EntryClient Entry { get; }
    public SearchClient Search { get; }

    ICharacterClient IHoyoWikiClient.Character => Character;
    IWeaponClient IHoyoWikiClient.Weapon => Weapon;
    IArtifactClient IHoyoWikiClient.Artifact => Artifact;
    IEntryClient IHoyoWikiClient.Entry => Entry;
    ISearchClient IHoyoWikiClient.Search => Search;

    public HoyoWikiClientImpl()
    {
        _client.BaseAddress = new Uri("https://sg-wiki-api.hoyolab.com/hoyowiki/wapi/");
        
        var headers = _client.DefaultRequestHeaders;
        headers.Referrer = new Uri("https://wiki.hoyolab.com");
        headers.Add("x-rpc-language", Language.EnglishUS.GetLocaleName());
        
        var agent = headers.UserAgent;
        agent.Clear();
        agent.Add(new ProductInfoHeaderValue("Mozilla", "5.0"));
        agent.Add(new ProductInfoHeaderValue("(Windows NT 10.0; Win64; x64)"));
        agent.Add(new ProductInfoHeaderValue("AppleWebKit", "537.36"));
        agent.Add(new ProductInfoHeaderValue("(KHTML, like Gecko)"));
        agent.Add(new ProductInfoHeaderValue("Chrome", "102.0.5005.63"));
        agent.Add(new ProductInfoHeaderValue("Safari", "537.36"));

        Character = new CharacterClient(_client);
        Weapon = new WeaponClient(_client);
        Artifact = new ArtifactClient(_client);
        Entry = new EntryClient(_client);
        Search = new SearchClient(_client);
    }

    public async Task SetLanguageAsync(Language language)
    {
        Language = language;

        var headers = _client.DefaultRequestHeaders;
        headers.Remove("x-rpc-language");
        headers.Add("x-rpc-language", language.GetLocaleName());

        await Character.Filters.UpdateFilterIdsAsync();
        await Weapon.Filters.UpdateFilterIdsAsync();
        await Artifact.Filters.UpdateFilterIdsAsync();
    }
}