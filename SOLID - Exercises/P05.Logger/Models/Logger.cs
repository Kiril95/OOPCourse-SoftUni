using System;
using System.Collections.Generic;
using System.Text;

namespace P05.Logger
{
    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            this.Appenders = appenders;
        }

        public IList<IAppender> Appenders { get; }

        public void Info(string dateTime, string message)
        {
            this.Log(dateTime, nameof(this.Info), message);
        }

        public void Warning(string dateTime, string message)
        {
            this.Log(dateTime, nameof(this.Warning), message);
        }

        public void Error(string dateTime, string message)
        {
            this.Log(dateTime, nameof(this.Error), message);
        }

        public void Critical(string dateTime, string message)
        {
            this.Log(dateTime, nameof(this.Critical), message);
        }

        public void Fatal(string dateTime, string message)
        {
            this.Log(dateTime, nameof(this.Fatal), message);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Logger info");

            foreach (IAppender appender in this.Appenders)
            {
                sb.AppendLine(appender.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        private void Log(string dateTime, string reportLevel, string message)
        {
            foreach (IAppender appender in this.Appenders)
            {
                ReportLevel reportThreshhold = (ReportLevel)Enum.Parse(typeof(ReportLevel), reportLevel);

                if (reportThreshhold >= appender.ReportLevel)
                {
                    appender.Append(dateTime, reportLevel, message);
                }
            }
        }
    }
}