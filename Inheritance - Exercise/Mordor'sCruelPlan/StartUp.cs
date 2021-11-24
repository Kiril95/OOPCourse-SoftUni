using System;

namespace Mordor_sCruelPlan
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            GandalfTheGrey gandalf = new GandalfTheGrey();

            foreach (var food in input)
            {
                gandalf.Eat(food);
            }

            Console.WriteLine(gandalf.GandalfMoodPoints);
            Console.WriteLine(gandalf.CalculateMood());
        }
    }
}
