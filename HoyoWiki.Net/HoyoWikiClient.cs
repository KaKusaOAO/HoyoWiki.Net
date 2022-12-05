namespace HoyoWiki.Net;

public static class HoyoWikiClient
{
    public static async Task<IHoyoWikiClient> CreateAsync(Language language)
    {
        var client = new HoyoWikiClientImpl();
        await client.SetLanguageAsync(language);
        return client;
    }
}