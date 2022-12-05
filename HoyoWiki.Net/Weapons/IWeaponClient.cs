using HoyoWiki.Net.Weapons.Models;

namespace HoyoWiki.Net.Weapons;

public interface IWeaponClient : IEntryPageListData<WeaponListData, WeaponList>
{
    public WeaponFilters Filters { get; }
}