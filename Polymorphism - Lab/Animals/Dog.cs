using System.Text;

namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string name, string favouriteFood) : base(name, favouriteFood)
        {
        }

        public override string ExplainSelf()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{base.ToString()}");
            sb.AppendLine("DJAAF");

            return sb.ToString().TrimEnd();
        }
    }
}