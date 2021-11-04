using System.Text;

namespace P03.DetailPrinter
{
    public class Employee : IWorker
    {
        public Employee(string name, int age, string country, string sector)
        {
            Name = name;
            Age = age;
            Country = country;
            Sector = sector;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Country { get; private set; }
        public string Sector { get; private set; }

        public virtual string ExplainSelf()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"My name is {this.Name} and I am {this.Age} years old from {this.Country} working in the {this.Sector} sector.");
            return sb.ToString().TrimEnd();
        }
    }
}
