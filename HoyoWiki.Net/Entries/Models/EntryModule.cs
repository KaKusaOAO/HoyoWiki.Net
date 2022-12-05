namespace HoyoWiki.Net.Entries.Models;

public class EntryModule
{
    public string Name { get; set; }
    public bool IsPopped { get; set; }
    public IEnumerable<EntryComponent> Components { get; set; }
    public string Id { get; set; }
}