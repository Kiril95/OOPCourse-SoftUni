namespace P05.Logger
{
    public class SimpleLayout : ILayout
    {
        public string FormatMessage(string dateTime, string reportLevel, string message)
        {
            return $"{dateTime} - {reportLevel} - {message}";
        }
    }
}