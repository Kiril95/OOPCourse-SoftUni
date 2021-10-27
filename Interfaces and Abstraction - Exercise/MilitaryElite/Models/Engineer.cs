using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private ICollection<Repair> repairs;
        public Engineer(string id, string firstName, string lastName, decimal salary, string corps, IList<Repair> repairs) 
                       : base(id, firstName, lastName, salary, corps)
        {
            Repairs = repairs;
        }

        public IList<Repair> Repairs { get; private set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{ base.ToString()}");
            sb.AppendLine("Repairs:");

            foreach (var repair in Repairs)
            {
                sb.AppendLine(repair.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
