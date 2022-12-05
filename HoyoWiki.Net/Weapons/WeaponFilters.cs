using System.Net.Http.Json;
using HoyoWiki.Net.Models;

namespace HoyoWiki.Net.Weapons;

public class WeaponFilters : IPageFilter
{
    private HttpClient _client;

    public WeaponFilters(HttpClient client)
    {
        _client = client;
    }

    public SecondaryAttributesFilters SecondaryAttributes { get; } = new();
    public TypeFilters Type { get; } = new();
    public QualityFilters Quality { get; } = new();

    public class SecondaryAttributesFilters
    {
        public readonly Filter AttackPercentage = new(136);
        public readonly Filter PhysicalDamageBonus = new(151);
        public readonly Filter DefensePercentage = new(164);
        public readonly Filter CriticalRate = new(176);
        public readonly Filter CriticalDamage = new(190);
        public readonly Filter ElementalMastery = new(199);
        public readonly Filter EnergyRecharge = new(211);
        public readonly Filter HealthPercentage = new(228);
    }
    
    public class TypeFilters
    {
        public readonly Filter Sword = new(398);
        public readonly Filter Claymore = new(407);
        public readonly Filter Bow = new(419);
        public readonly Filter Catalyst = new(439);
        public readonly Filter Polearm = new(443);
    }
    
    public class QualityFilters
    {
        public readonly Filter Star5 = new(673);
        public readonly Filter Star4 = new(683);
        public readonly Filter Star3 = new(696);
        public readonly Filter Star2 = new(712);
        public readonly Filter Star1 = new(724);
    }

    public async Task UpdateFilterIdsAsync()
    {
        var filters = await IPageFilter.GetFilters(_client, EntryPageMenu.Weapons);
        UpdateSecondaryAttributesFilters(filters?.GetOrDefault(0));
        UpdateTypeFilters(filters?.GetOrDefault(1));
        UpdateQualityFilters(filters?.GetOrDefault(2));
    }

    private void UpdateSecondaryAttributesFilters(MenuFiltersFilter? filter)
    {
        var values = filter?.GetValuesAsList();

        SecondaryAttributes.AttackPercentage.OverrideId = values?.GetOrDefault(0)?.Id.ToInt32();
        SecondaryAttributes.PhysicalDamageBonus.OverrideId = values?.GetOrDefault(1)?.Id.ToInt32();
        SecondaryAttributes.DefensePercentage.OverrideId = values?.GetOrDefault(2)?.Id.ToInt32();
        SecondaryAttributes.CriticalRate.OverrideId = values?.GetOrDefault(3)?.Id.ToInt32();
        SecondaryAttributes.CriticalDamage.OverrideId = values?.GetOrDefault(4)?.Id.ToInt32();
        SecondaryAttributes.ElementalMastery.OverrideId = values?.GetOrDefault(5)?.Id.ToInt32();
        SecondaryAttributes.EnergyRecharge.OverrideId = values?.GetOrDefault(6)?.Id.ToInt32();
        SecondaryAttributes.HealthPercentage.OverrideId = values?.GetOrDefault(7)?.Id.ToInt32();
    }
    
    private void UpdateTypeFilters(MenuFiltersFilter? filter)
    {
        var values = filter?.GetValuesAsList();

        Type.Sword.OverrideId = values?.GetOrDefault(0)?.Id.ToInt32();
        Type.Claymore.OverrideId = values?.GetOrDefault(1)?.Id.ToInt32();
        Type.Bow.OverrideId = values?.GetOrDefault(2)?.Id.ToInt32();
        Type.Catalyst.OverrideId = values?.GetOrDefault(3)?.Id.ToInt32();
        Type.Polearm.OverrideId = values?.GetOrDefault(4)?.Id.ToInt32();
    }

    private void UpdateQualityFilters(MenuFiltersFilter? filter)
    {
        var values = filter?.GetValuesAsList();
        
        Quality.Star5.OverrideId = values?.GetOrDefault(0)?.Id.ToInt32();
        Quality.Star4.OverrideId = values?.GetOrDefault(1)?.Id.ToInt32();
        Quality.Star3.OverrideId = values?.GetOrDefault(2)?.Id.ToInt32();
        Quality.Star2.OverrideId = values?.GetOrDefault(3)?.Id.ToInt32();
        Quality.Star1.OverrideId = values?.GetOrDefault(4)?.Id.ToInt32();
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