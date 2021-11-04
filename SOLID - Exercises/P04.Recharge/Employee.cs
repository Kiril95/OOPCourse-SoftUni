namespace P04.Recharge
{
    public class Employee : Worker, ISleeper
    {
        public Employee(string id) : base(id)
        {
        }

        public string Sleep()
        {
            return "Sleeping...";
        }
    }
}
