using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] websites = Console.ReadLine().Split();
            Smartphone smartPhone = new Smartphone();
            StationaryPhone statPhone = new StationaryPhone();

            foreach (var number in phoneNumbers)
            {
                if (number.Length == 10)
                {
                    Console.WriteLine(smartPhone.Call(number));
                }

                else if (number.Length == 7)
                {
                    Console.WriteLine(statPhone.Call(number));
                }

                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            foreach (var sites in websites)
            {
                Console.WriteLine(smartPhone.Browse(sites));
            }

        }
    }
}
