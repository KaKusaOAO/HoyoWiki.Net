using HoyoWiki.Net.Weapons.Models;

namespace HoyoWiki.Net.Weapons;

public class WeaponClient : BaseEntryPageClient<WeaponListData, WeaponList>, IWeaponClient
{
    public WeaponFilters Filters { get; }

    public WeaponClient(HttpClient client)
    {
        HttpClient = client;
        Filters = new WeaponFilters(client);
    }

    protected override HttpClient HttpClient { get; }

    protected override EntryPageMenu Menu => EntryPageMenu.Weapons;
}