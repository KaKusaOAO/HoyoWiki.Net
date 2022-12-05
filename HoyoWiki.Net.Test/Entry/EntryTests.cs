using HoyoWiki.Net.Characters.Models;
using HoyoWiki.Net.Entries;

namespace HoyoWiki.Net.Test.Entry;

public class EntryTests
{
    private IHoyoWikiClient _client;
    private IEntryClient _entry;

    [SetUp]
    public async Task SetupAsync()
    {
        _client = await HoyoWikiClient.CreateAsync(Language.EnglishUS);
        _entry = _client.Entry;
    }

    [Test]
    public async Task TestEntryId()
    {
        var result = (await _entry.GetAsPageAsync<CharacterPage>(2252))!;
        Assert.That(result.Id, Is.EqualTo("2252"));
    }
    
    [Test]
    public async Task TestEntryName()
    {
        var result = (await _entry.GetAsPageAsync<CharacterPage>(2252))!;
        Assert.That(result.Name, Is.EqualTo("Yelan"));
    }

    [Test]
    public async Task TestEntryMenuId()
    {
        var result = (await _entry.GetAsPageAsync<CharacterPage>(2252))!;
        Assert.That(result.MenuId, Is.EqualTo(((int)EntryPageMenu.Character).ToString()));
    }

    [Test]
    public async Task TestEntryFilterValues()
    {
        var result = (await _entry.GetAsPageAsync<CharacterPage>(2252))!;
        Assert.That(result.FilterValues.Vision.Values.ToList().FirstOrDefault(), Is.EqualTo("Hydro"));
    }
}