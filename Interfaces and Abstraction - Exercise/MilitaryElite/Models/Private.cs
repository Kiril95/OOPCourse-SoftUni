namespace MilitaryElite
{
    public class Private : Soldier, IPrivate
    {
        private decimal salary;
        public Private(string id, string firstName, string lastName, decimal salary)
                       : base(id, firstName, lastName)
        {
            Salary = salary;
        }
        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return $"{base.ToString()} Salary: {Salary:f2}";
        }

    }
}
