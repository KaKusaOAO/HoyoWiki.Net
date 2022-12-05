namespace HoyoWiki.Net.Artifacts;

public class ArtifactFilters : IPageFilter
{
    private HttpClient _client;

    public ArtifactFilters(HttpClient client)
    {
        _client = client;
    }

    public ReliquaryEffectFilters ReliquaryEffect { get; } = new();

    public class ReliquaryEffectFilters
    {
        public readonly Filter Attack = new(240);
        public readonly Filter DamageBonus = new(254);
        public readonly Filter Health = new(265);
        public readonly Filter ShieldStrength = new(283);
        public readonly Filter Defense = new(294);
        public readonly Filter CriticalRate = new(308);
        public readonly Filter ElementalMastery = new(319);
        public readonly Filter EnergyRecharge = new(333);
        public readonly Filter CooldownReduction = new(346);
        public readonly Filter HealingBonus = new(359);
        public readonly Filter ElementalEffects = new(373);
        public readonly Filter ElementalRes = new(384);
    }
    
    public async Task UpdateFilterIdsAsync()
    {
        var filters = await IPageFilter.GetFilters(_client, EntryPageMenu.Artifact);
        var values = filters?.GetOrDefault(0)?.GetValuesAsList();
        
        ReliquaryEffect.Attack.OverrideId = values?.GetOrDefault(0)?.Id.ToInt32();
        ReliquaryEffect.DamageBonus.OverrideId = values?.GetOrDefault(1)?.Id.ToInt32();
        ReliquaryEffect.Health.OverrideId = values?.GetOrDefault(2)?.Id.ToInt32();
        ReliquaryEffect.ShieldStrength.OverrideId = values?.GetOrDefault(3)?.Id.ToInt32();
        ReliquaryEffect.Defense.OverrideId = values?.GetOrDefault(4)?.Id.ToInt32();
        ReliquaryEffect.CriticalRate.OverrideId = values?.GetOrDefault(5)?.Id.ToInt32();
        ReliquaryEffect.ElementalMastery.OverrideId = values?.GetOrDefault(6)?.Id.ToInt32();
        ReliquaryEffect.EnergyRecharge.OverrideId = values?.GetOrDefault(7)?.Id.ToInt32();
        ReliquaryEffect.CooldownReduction.OverrideId = values?.GetOrDefault(8)?.Id.ToInt32();
        ReliquaryEffect.HealingBonus.OverrideId = values?.GetOrDefault(9)?.Id.ToInt32();
        ReliquaryEffect.ElementalEffects.OverrideId = values?.GetOrDefault(10)?.Id.ToInt32();
        ReliquaryEffect.ElementalRes.OverrideId = values?.GetOrDefault(11)?.Id.ToInt32();
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