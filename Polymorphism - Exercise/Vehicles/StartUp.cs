using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] truckInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int times = int.Parse(Console.ReadLine());
            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            for (int i = 0; i < times; i++)
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = info[0];
                string type = info[1];
                double distOrAmount = double.Parse(info[2]);

                if (type == nameof(Car))
                {
                    if (action == "Drive")
                    {
                        Console.WriteLine(car.Drive(distOrAmount));
                    }
                    else if (action == "Refuel")
                    {
                        car.Refuel(distOrAmount);
                    }
                }
                else if (type == nameof(Truck))
                {
                    if (action == "Drive")
                    {
                        Console.WriteLine(truck.Drive(distOrAmount));
                    }
                    else if (action == "Refuel")
                    {
                        truck.Refuel(distOrAmount);
                    }
                }
            }
            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }
    }
}
