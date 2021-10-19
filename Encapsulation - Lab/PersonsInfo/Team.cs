using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;
        public Team(string name)
        {
            this.Name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public string Name { get; set; }
        public IReadOnlyList<Person> FirstTeam => this.firstTeam.AsReadOnly();
        public IReadOnlyList<Person> ReserveTeam => this.reserveTeam.AsReadOnly();

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

              sb.AppendLine($"First team has {FirstTeam.Count} players.")
                .AppendLine($"Reserve team has {ReserveTeam.Count} players.");

            return sb.ToString().TrimEnd();
        }
    }
}
