using System.Text;

namespace P05.Logger
{
    public class XmlLayout : ILayout
    {
        public string FormatMessage(string dateTime, string reportLevel, string message)
        {
            var sb = new StringBuilder();
              sb.AppendLine("<log>")
                .AppendLine($"   <date>{dateTime}</date>")
                .AppendLine($"   <level>{reportLevel}</level>")
                .AppendLine($"   <message>{message}</message>")
                .AppendLine("</log>");

            return sb.ToString().TrimEnd();
        }
    }
}