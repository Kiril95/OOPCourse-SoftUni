using System;
using System.Text;

namespace MilitaryElite
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private Corps corps;
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps) 
                            : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }
        public string Corps
        {
            get => corps.ToString();

            private set
            {
                Corps corps;

                if (!Enum.TryParse(value, out corps))
                {
                    throw new ArgumentException();
                }

                this.corps = corps;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{ base.ToString()}");
            sb.AppendLine($"Corps: {Corps}");

            return sb.ToString().TrimEnd();
        }
    }
}
