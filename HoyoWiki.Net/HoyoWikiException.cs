namespace HoyoWiki.Net;

public class HoyoWikiException : Exception
{
    public int ReturnCode { get; }
    
    public HoyoWikiException(string message, int returnCode) : base(message)
    {
        ReturnCode = returnCode;
    }
}