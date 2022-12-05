using HoyoWiki.Net.Characters.Models;

namespace HoyoWiki.Net.Characters;

public interface ICharacterClient : IEntryPageListData<CharacterListData, CharacterList>
{
    public CharacterFilters Filters { get; }
}