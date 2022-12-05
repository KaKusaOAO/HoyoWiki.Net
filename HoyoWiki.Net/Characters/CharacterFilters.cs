using System.Net.Http.Json;
using HoyoWiki.Net.Models;

namespace HoyoWiki.Net.Characters;

public class CharacterFilters : IPageFilter
{
    private HttpClient _client;

    public ElementalTypeFilters ElementalType { get; } = new();
    public RegionFilters Region { get; } = new();
    public QualityFilters Quality { get; } = new();
    public WeaponTypeFilters WeaponType { get; } = new();
    
    public CharacterFilters(HttpClient client)
    {
        _client = client;
    }
    
    public class ElementalTypeFilters
    {
        public readonly Filter Pyro = new(737);
        public readonly Filter Hydro = new(745);
        public readonly Filter Dendro = new(763);
        public readonly Filter Electro = new(780);
        public readonly Filter Anemo = new(789);
        public readonly Filter Cryo = new(803);
        public readonly Filter Geo = new(814);
    }

    public class RegionFilters
    {
        public readonly Filter Mondstadt = new(27);
        public readonly Filter LiyueHarbor = new(43);
        public readonly Filter InazumaCity = new(60);
        public readonly Filter Snezhnaya = new(1414);
        public readonly Filter Sumeru = new(1418);
        public readonly Filter Fontaine = new(1434);
        public readonly Filter Natlan = new(1450);
    }

    public class QualityFilters
    {
        public readonly Filter Star5 = new(3);
        public readonly Filter Star4 = new(16);
    }

    public class WeaponTypeFilters
    {
        public readonly Filter Sword = new(72);
        public readonly Filter Claymore = new(81);
        public readonly Filter Bow = new(96);
        public readonly Filter Catalyst = new(117);
        public readonly Filter Polearm = new(126);
    }

    public async Task UpdateFilterIdsAsync()
    {
        var filters = await IPageFilter.GetFilters(_client, EntryPageMenu.Character);
        UpdateElementalTypeFilters(filters?.GetOrDefault(0));
        UpdateRegionFilters(filters?.GetOrDefault(1));
        UpdateQualityFilters(filters?.GetOrDefault(2));
        UpdateWeaponTypeFilters(filters?.GetOrDefault(4));
    }

    private void UpdateElementalTypeFilters(MenuFiltersFilter? filter)
    {
        var values = filter?.GetValuesAsList();
        ElementalType.Pyro.OverrideId = values?.GetOrDefault(0)?.Id.ToInt32();
        ElementalType.Hydro.OverrideId = values?.GetOrDefault(1)?.Id.ToInt32();
        ElementalType.Dendro.OverrideId = values?.GetOrDefault(2)?.Id.ToInt32();
        ElementalType.Electro.OverrideId = values?.GetOrDefault(3)?.Id.ToInt32();
        ElementalType.Anemo.OverrideId = values?.GetOrDefault(4)?.Id.ToInt32();
        ElementalType.Cryo.OverrideId = values?.GetOrDefault(5)?.Id.ToInt32();
        ElementalType.Geo.OverrideId = values?.GetOrDefault(6)?.Id.ToInt32();
    }

    private void UpdateRegionFilters(MenuFiltersFilter? filter)
    {
        var values = filter?.GetValuesAsList();
        Region.Mondstadt.OverrideId = values?.GetOrDefault(0)?.Id.ToInt32();
        Region.LiyueHarbor.OverrideId = values?.GetOrDefault(1)?.Id.ToInt32();
        Region.InazumaCity.OverrideId = values?.GetOrDefault(2)?.Id.ToInt32();
        Region.Snezhnaya.OverrideId = values?.GetOrDefault(3)?.Id.ToInt32();
        Region.Sumeru.OverrideId = values?.GetOrDefault(4)?.Id.ToInt32();
        Region.Fontaine.OverrideId = values?.GetOrDefault(5)?.Id.ToInt32();
        Region.Natlan.OverrideId = values?.GetOrDefault(6)?.Id.ToInt32();
    }

    private void UpdateQualityFilters(MenuFiltersFilter? filter)
    {
        var values = filter?.GetValuesAsList();
        Quality.Star5.OverrideId = values?.GetOrDefault(0)?.Id.ToInt32();
        Quality.Star4.OverrideId = values?.GetOrDefault(1)?.Id.ToInt32();
    }

    private void UpdateWeaponTypeFilters(MenuFiltersFilter? filter)
    {
        var values = filter?.GetValuesAsList();
        WeaponType.Sword.OverrideId = values?.GetOrDefault(0)?.Id.ToInt32();
        WeaponType.Claymore.OverrideId = values?.GetOrDefault(1)?.Id.ToInt32();
        WeaponType.Bow.OverrideId = values?.GetOrDefault(2)?.Id.ToInt32();
        WeaponType.Catalyst.OverrideId = values?.GetOrDefault(3)?.Id.ToInt32();
        WeaponType.Polearm.OverrideId = values?.GetOrDefault(4)?.Id.ToInt32();
    }
}

file static class Extension 
{
    public static int? ToInt32(this string? self)
    {
        if (self == null) return null;
        return int.Parse(self);
    }
    
    public static T? GetOrDefault<T>(this List<T>? self, int i)
    {
        if (self == null) return default;
        if (i < 0) return default;
        if (self.Count <= i) return default;
        return self[i];
    }
}