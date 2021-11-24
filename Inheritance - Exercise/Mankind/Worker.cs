using System;
using System.Text;

namespace Mankind
{
    public class Worker : Human
    {
        private decimal weeklySalary;
        private decimal workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weeklySalary, decimal workHoursPerDay) 
            : base(firstName, lastName)
        {
            WeeklySalary = weeklySalary;
            WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeeklySalary
        {
            get => this.weeklySalary;
            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                this.weeklySalary = value;
            }
        }

        public decimal WorkHoursPerDay
        {
            get => this.workHoursPerDay;
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
                this.workHoursPerDay = value;
            }
        }

        private decimal CalculateSalaryPerHour()
        {
            return this.WeeklySalary / 5 / this.WorkHoursPerDay;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString())
              .AppendLine($"Week Salary: {this.WeeklySalary:f2}")
              .AppendLine($"Hours per day: {this.WorkHoursPerDay:f2}")
              .AppendLine($"Salary per hour: {this.CalculateSalaryPerHour():f2}");

            return sb.ToString().TrimEnd();
        }

    }
}