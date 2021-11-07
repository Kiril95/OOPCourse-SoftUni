using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Collector
{
    public class Spy
    {
        public string StealFieldInfo(string className)
        {
            Type typeOfClass = Type.GetType(className);
            MethodInfo[] methods = typeOfClass?.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            foreach (MethodInfo method in (methods ?? throw new InvalidOperationException()).Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (MethodInfo method in methods.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.ReturnParameter}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}