using System.Collections.Generic;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Components
{
    public class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                IEnumerable<MyValidationAttribute> customAttributes = property.GetCustomAttributes<MyValidationAttribute>();

                foreach (MyValidationAttribute attribute in customAttributes)
                {
                    if (attribute.IsValid(property.GetValue(obj)) == false)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}