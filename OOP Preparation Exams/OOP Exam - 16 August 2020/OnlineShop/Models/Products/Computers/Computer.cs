using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components = new List<IComponent>();
        private List<IPeripheral> peripherals = new List<IPeripheral>();

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
        }

        public IReadOnlyCollection<IComponent> Components => this.components.AsReadOnly();
        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.AsReadOnly();

        public override double OverallPerformance => this.CalculateOverallPerformance();
        public override decimal Price => this.CalculateTotalPrice();

        public void AddComponent(IComponent component)
        {
            if (components.Any(x => x.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(string
                    .Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));
            }

            this.components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            var targetComp = components.FirstOrDefault(x => x.GetType().Name == componentType);

            if (!components.Any() || targetComp == null)
            {
                throw new ArgumentException(string
                    .Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }

            this.components.Remove(targetComp);
            return targetComp;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(string
                    .Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            this.peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var targetPeripheral = peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);

            if (!peripherals.Any() || targetPeripheral == null)
            {
                throw new ArgumentException(string
                    .Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }

            this.peripherals.Remove(targetPeripheral);
            return targetPeripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString()).AppendLine($" Components ({this.Components.Count}):");

            foreach (var component in this.Components)
            {
                sb.AppendLine($"  {component}");
            }

            sb.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance " +
                          $"({this.peripherals.Average(x => x.OverallPerformance)}):");

            foreach (var peripheral in this.Peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return sb.ToString().TrimEnd();
        }

        private decimal CalculateTotalPrice()
        {
            var comp = components.Sum(x => x.Price);
            var peri = peripherals.Sum(x => x.Price);

            return comp + peri + base.Price;
        }

        private double CalculateOverallPerformance()
        {
            if (!components.Any())
            {
                return base.OverallPerformance;
            }

            var average = components.Average(x => x.OverallPerformance);
            return average + base.OverallPerformance;
        }

    }
}