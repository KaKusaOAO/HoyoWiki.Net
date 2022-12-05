using System.Diagnostics.CodeAnalysis;

namespace HoyoWiki.Net;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public enum Language
{
    ChineseCN,
    ChineseTW,
    German,
    EnglishUS,
    SpanishES,
    French,
    Indonesia,
    Japanese,
    Korean,
    Portuguese,
    Russian,
    Thai,
    Vietnamese
}

public static class LanguageExtension
{
    private class Data
    {
        public string Name { get; init; }
    }

    private static readonly Dictionary<Language, Data> _map = new();

    static LanguageExtension()
    {
        void AddData(Language lang, string name)
        {
            _map.Add(lang, new Data
            {
                Name = name
            });
        }
        
        AddData(Language.ChineseCN, "zh-cn");
        AddData(Language.ChineseTW, "zh-tw");
        AddData(Language.German, "de-de");
        AddData(Language.EnglishUS, "en-us");
        AddData(Language.SpanishES, "es-es");
        AddData(Language.French, "fr-fr");
        AddData(Language.Indonesia, "id-id");
        AddData(Language.Japanese, "ja-jp");
        AddData(Language.Korean, "ko-kr");
        AddData(Language.Portuguese, "pt-pt");
        AddData(Language.Russian, "ru-ru");
        AddData(Language.Thai, "th-th");
        AddData(Language.Vietnamese, "vi-vn");
    }

    public static string GetLocaleName(this Language self) => _map[self].Name;
}