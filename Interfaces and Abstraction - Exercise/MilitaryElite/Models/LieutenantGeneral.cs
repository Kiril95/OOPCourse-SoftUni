using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private IList<Private> privates;
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, IList<Private> privates) 
                                : base(id, firstName, lastName, salary)
        {
            Privates = privates;
        }
        public IList<Private> Privates { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{base.ToString()}");
            sb.AppendLine("Privates:");

            foreach (var @private in Privates)
            {
                sb.AppendLine(@private.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
