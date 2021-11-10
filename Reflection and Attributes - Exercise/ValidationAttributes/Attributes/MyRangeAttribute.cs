using System;
using System.Globalization;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int _minValue;
        private readonly int _maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this._minValue = minValue;
            this._maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            bool check = Int32.TryParse(Convert.ToString(obj
                , CultureInfo.InvariantCulture)
                , NumberStyles.Any
                , NumberFormatInfo.InvariantInfo
                , out var value);

            if (value >= _minValue && value <= _maxValue)
            {
                return true;
            }

            return false;
        }
    }
}