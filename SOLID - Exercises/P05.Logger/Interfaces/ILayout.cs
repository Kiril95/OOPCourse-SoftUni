namespace P05.Logger
{
    public interface ILayout
    {
        string FormatMessage(string dateTime, string reportLevel, string message);
    }
}