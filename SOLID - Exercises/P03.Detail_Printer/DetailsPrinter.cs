using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    public class DetailsPrinter
    {
        private IList<Employee> employees;

        public DetailsPrinter(IList<Employee> employees)
        {
            this.employees = employees;
        }

        public void PrintInformation()
        {
            foreach (Employee employee in this.employees)
            {
                Console.WriteLine(employee.ExplainSelf());
            }
        }
    }
}
