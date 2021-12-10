using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers = new List<IComputer>();
        private List<IComponent> components = new List<IComponent>();
        private List<IPeripheral> peripherals = new List<IPeripheral>();

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == id);

            if (computer != null)
            {
                throw new ArgumentException("Computer with this id already exists.");
            }

            if (computerType == Common.Enums.ComputerType.DesktopComputer.ToString())
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else if (computerType == Common.Enums.ComputerType.Laptop.ToString())
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException("Computer type is invalid.");
            }

            this.computers.Add(computer);
            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price,
            double overallPerformance, string connectionType)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);

            if (computer is null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            var targetPeripheral = this.peripherals.FirstOrDefault(c => c.Id == id);

            if (targetPeripheral != null)
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }

            if (peripheralType == Common.Enums.PeripheralType.Headset.ToString())
            {
                targetPeripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == Common.Enums.PeripheralType.Keyboard.ToString())
            {
                targetPeripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == Common.Enums.PeripheralType.Monitor.ToString())
            {
                targetPeripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == Common.Enums.PeripheralType.Mouse.ToString())
            {
                targetPeripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException("Peripheral type is invalid.");
            }

            computer.AddPeripheral(targetPeripheral);
            this.peripherals.Add(targetPeripheral);

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);
            if (computer is null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            var targetPeripheral = computer.RemovePeripheral(peripheralType);

            this.peripherals.Remove(targetPeripheral);

            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, targetPeripheral.Id);
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price,
            double overallPerformance, int generation)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);

            if (computer is null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            var targetComponent = this.components.FirstOrDefault(c => c.Id == id);

            if (targetComponent != null)
            {
                throw new ArgumentException("Component with this id already exists.");
            }

            if (componentType == Common.Enums.ComponentType.CentralProcessingUnit.ToString())
            {
                targetComponent = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == Common.Enums.ComponentType.Motherboard.ToString())
            {
                targetComponent = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == Common.Enums.ComponentType.PowerSupply.ToString())
            {
                targetComponent = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == Common.Enums.ComponentType.RandomAccessMemory.ToString())
            {
                targetComponent = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == Common.Enums.ComponentType.SolidStateDrive.ToString())
            {
                targetComponent = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == Common.Enums.ComponentType.VideoCard.ToString())
            {
                targetComponent = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException("Component type is invalid.");
            }

            this.components.Add(targetComponent);
            computer.AddComponent(targetComponent);

            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);

            if (computer is null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            IComponent targetComponent = computer.RemoveComponent(componentType);

            this.components.Remove(targetComponent);

            return string.Format(SuccessMessages.RemovedComponent, componentType, targetComponent.Id);
        }

        public string BuyComputer(int id)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == id);

            if (computer is null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            this.computers.Remove(computer);

            return computer.ToString();
        }

        public string BuyBest(decimal budget)
        {
            IComputer targetComputer = this.computers
                .Where(c => c.Price <= budget)
                .OrderByDescending(c => c.OverallPerformance)
                .FirstOrDefault();

            if (targetComputer is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            this.computers.Remove(targetComputer);
            return targetComputer.ToString();
        }

        public string GetComputerData(int id)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == id);
            if (computer is null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            return computer.ToString();
        }
    }
}