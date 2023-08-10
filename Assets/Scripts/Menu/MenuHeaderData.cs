public static class MenuHeaderData
{
    private static readonly string _gameName = "KILLING DOGES";

    private static string _current;

    static MenuHeaderData()
    {
        _current = _gameName;
    }

    public static void Set(string text)
    {
        _current = text;
    }

    public static void Get(out string text)
    {
        text = _current;
        _current = _gameName;
    }
}