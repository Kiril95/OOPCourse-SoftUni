using System;

namespace HighQualityMistakes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Spy spy = new Spy();
                string className = typeof(Hacker).FullName;
                string result = spy.AnalyzeAccessModifiers(className);
                Console.WriteLine(result);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Value cannot be null!");
            }
        }
    }
}
