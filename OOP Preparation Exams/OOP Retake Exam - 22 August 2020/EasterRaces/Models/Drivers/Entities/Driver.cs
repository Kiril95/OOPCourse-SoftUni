using System;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private const int MinimumSymbols = 5;
        private string name;

        public Driver(string name)
        {
            this.Name = name;
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
        public ICar Car { get; private set; }
        public int NumberOfWins { get; private set; }
        public bool CanParticipate => this.Car != null;

        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public void AddCar(ICar car)
        {
            this.Car = car ?? throw new ArgumentNullException(string.Format(ExceptionMessages.CarInvalid));
        }
    }
}