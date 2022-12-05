using System.Text.Json;
using System.Text.Json.Nodes;
using HoyoWiki.Net.Entries.Models;

namespace HoyoWiki.Net.Entries;

public interface IEntryClient
{
    public Task<JsonObject> GetAsync(int id);
}

public static class EntryClientExtension
{
    public static async Task<T?> GetAsPageAsync<T>(this IEntryClient client, int id) where T : AbstractPage
    {
        var obj = await client.GetAsync(id);
        return obj.Deserialize<T>();
    }
}