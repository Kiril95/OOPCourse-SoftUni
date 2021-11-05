using System;
using System.IO;
using System.Linq;
using System.Text;

namespace P05.Logger
{
    public class LogFile
    {
        private const string DefaultFileName = "log.txt";
        private readonly StringBuilder sb;

        public LogFile()
        {
            this.sb = new StringBuilder();
        }

        public int Size => this.GetSumOfLetters();

        public void Write(string message)
        {
            this.sb.AppendLine(message);
            File.AppendAllText(DefaultFileName, message + Environment.NewLine);
        }

        private int GetSumOfLetters()
        {
            return this.sb
                .ToString()
                .Where(char.IsLetter)
                .Sum(x => x);
        }
    }
}