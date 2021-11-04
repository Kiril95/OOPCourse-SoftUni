using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            ICollection<string> docs = new List<string>() { "report.txt", "overtimehours.txt" };
            Manager manager = new Manager("Grisho", 25, "Bulgaria", "Manager","Management", docs);
            DetailsPrinter printer = new DetailsPrinter(new List<Employee>() { manager });
            Accountant acc = new Accountant("Billy", 25, "Mars", "Bar");
            Console.WriteLine(acc.ExplainSelf());
            printer.PrintInformation();
        }
    }
}
