using System;

namespace MissionPrivateImpossible
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string className = typeof(Hacker).FullName;
            string result = spy.RevealPrivateMethods(className);
            Console.WriteLine(result);
        }
    }
}
