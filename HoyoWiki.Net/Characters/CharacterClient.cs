using HoyoWiki.Net.Characters.Models;

namespace HoyoWiki.Net.Characters;

public class CharacterClient : BaseEntryPageClient<CharacterListData, CharacterList>, ICharacterClient
{
    public CharacterFilters Filters { get; }

    public CharacterClient(HttpClient client)
    {
        HttpClient = client;
        Filters = new CharacterFilters(client);
    }

    protected override HttpClient HttpClient { get; }

    protected override EntryPageMenu Menu => EntryPageMenu.Character;
}