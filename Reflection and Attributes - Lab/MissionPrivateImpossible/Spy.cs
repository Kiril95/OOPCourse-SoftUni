using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MissionPrivateImpossible
{
    public class Spy
    {
        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"All Private Methods of Class: {className}")
              .AppendLine($"Base Class: {classType?.BaseType?.Name}");

            classType?.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                      .ToList()
                      .ForEach(m => sb.AppendLine($"{m.Name}"));

            return sb.ToString().TrimEnd();
        }
    }
}