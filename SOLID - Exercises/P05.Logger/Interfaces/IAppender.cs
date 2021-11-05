namespace P05.Logger
{
    public interface IAppender
    {
        ILayout Layout { get; }
        ReportLevel ReportLevel { get; set; }
        void Append(string dateTime, string reportLevel, string message);
    }
}