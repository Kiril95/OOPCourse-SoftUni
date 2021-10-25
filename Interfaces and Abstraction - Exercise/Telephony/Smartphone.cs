using System.Linq;

namespace Telephony
{
    public class Smartphone : ICalling, IBrowsing
    {
        public string Call(string number)
        {
            if (number.All(char.IsDigit))
            {
                return $"Calling... {number}";
            }

            return "Invalid number!";
        }
        
        public string Browse(string url)
        {
            if (url.Any(char.IsDigit))
            {
                return "Invalid URL!";
            }

            return $"Browsing: {url}!";
        }
    }
}
