using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class Manager : Employee
    {
        public Manager(string name, int age, string country, string position, string sector, ICollection<string> documents) : base(name, age, country, sector)
        {
            this.Documents = documents;
        }

        public ICollection<string> Documents { get; private set; }
        public override string ExplainSelf()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ExplainSelf());
            sb.AppendLine(string.Join(Environment.NewLine, this.Documents));

            return sb.ToString().TrimEnd();
        }
    }
}
