using System;

namespace P04.Recharge
{
    class Program
    {
        static void Main()
        {
            Robot robot = new Robot("C-3PO", 777);
            Employee employee = new Employee("Skywalker");
            RechargeStation station = new RechargeStation();
            station.Recharge(robot);
            robot.Work(10);
            employee.Work(6);
            
            Console.WriteLine(robot.CurrentPower);
            Console.WriteLine(employee.Sleep());
        }
    }
}
