using System;
using System.Collections.Generic;
using System.Linq;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private const int MinimumSymbols = 5;
        private const int MinimumLaps = 1;
        private List<IDriver> drivers = new List<IDriver>();
        private string name;
        private int laps;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MinimumSymbols)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, MinimumSymbols));
                }

                this.name = value;
            }
        }
        public int Laps
        {
            get => this.laps;

            private set
            {
                if (value < MinimumLaps)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, MinimumLaps));
                }

                this.laps = value;
            }
        }
        public IReadOnlyCollection<IDriver> Drivers => this.drivers.AsReadOnly();

        public void AddDriver(IDriver driver)
        {
            if (driver is null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }

            if (!driver.CanParticipate)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }

            if (drivers.Any(x => x.Name == driver.Name))
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));
            }

            this.drivers.Add(driver);
        }
    }
}