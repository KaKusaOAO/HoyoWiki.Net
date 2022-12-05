using HoyoWiki.Net.Artifacts;
using HoyoWiki.Net.Artifacts.Models;

namespace HoyoWiki.Net.Test.EntryPage;

public class ArtifactTests
{
    private IHoyoWikiClient _client;
    private IArtifactClient _artifact;

    [SetUp]
    public async Task SetupAsync()
    {
        _client = await HoyoWikiClient.CreateAsync(Language.EnglishUS);
        _artifact = _client.Artifact;
    }

    [Test]
    public async Task TestListHasItem()
    {
        var result = (await _artifact.GetListAsync(
            _artifact.Filters.ReliquaryEffect.Attack,
            _artifact.Filters.ReliquaryEffect.CriticalRate)).ToList();
        Assert.That(result, Is.Not.Empty);
    }
    
    [Test]
    public async Task TestItemName()
    {
        var result = (await _artifact.GetListAsync()).Reverse().ToList();
        Assert.That(result[0].Name, Is.EqualTo("Adventurer"));
    }
    
    [Test]
    public async Task TestItemId()
    {
        var result = (await _artifact.GetListAsync()).Reverse().ToList();
        Assert.That(result[0].EntryPageId, Is.EqualTo("2061"));
    }
    
    [Test]
    public async Task TestTotal()
    {
        var result = await _artifact.GetTotalAsync();
        Assert.That(result, Is.GreaterThan(0));
    }
    
    [Test]
    public async Task TestTotalFiltered()
    {
        var result = await _artifact.GetTotalAsync(
            _artifact.Filters.ReliquaryEffect.Attack,
            _artifact.Filters.ReliquaryEffect.CriticalRate);
        Assert.That(result, Is.GreaterThan(0));
    }
}