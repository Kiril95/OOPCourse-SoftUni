using System;
using System.Text;

namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string name, string favouriteFood) : base(name, favouriteFood)
        {
        }

        public override string ExplainSelf()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{base.ToString()}");
            sb.AppendLine("MEEOW");

            return sb.ToString().TrimEnd();
        }
    }
}