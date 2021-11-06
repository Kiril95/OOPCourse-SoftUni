using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string classForInvestigation, params string[] fieldsForInvestigation)
        {
            Type typeClass = Type.GetType(classForInvestigation);
            FieldInfo[] fields = typeClass?.GetFields(BindingFlags.Static | BindingFlags.Instance | 
                                                               BindingFlags.NonPublic | BindingFlags.Public);
            Object classInstance = Activator.CreateInstance(typeClass ?? throw new ArgumentNullException(), new object[] { });

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {classForInvestigation}");

            foreach (FieldInfo field in fields ?? Enumerable.Empty<object>())
            {
                if (fieldsForInvestigation.Contains(field.Name))
                {
                    sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}