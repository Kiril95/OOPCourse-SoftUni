using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private CarRepository carRepo = new CarRepository();
        private DriverRepository driverRepo = new DriverRepository();
        private RaceRepository raceRepo = new RaceRepository();

        public ChampionshipController()
        {
        }

        public string CreateDriver(string driverName)
        {
            var targetDriver = driverRepo.GetByName(driverName);

            if (targetDriver != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            IDriver driver = new Driver(driverName);
            this.driverRepo.Add(driver);
            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = default;

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            var targetCar = carRepo.GetByName(model);

            if (targetCar != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            this.carRepo.Add(car);
            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string CreateRace(string name, int laps)
        {
            var targetRace = raceRepo.GetByName(name);

            if (targetRace != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            IRace race = new Race(name, laps);
            this.raceRepo.Add(race);
            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var targetRace = raceRepo.GetByName(raceName);
            var targetDriver = driverRepo.GetByName(driverName);

            if (targetRace is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (targetDriver is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            targetRace.AddDriver(targetDriver);
            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            var targetCar = carRepo.GetByName(carModel);
            var targetDriver = driverRepo.GetByName(driverName);

            if (targetCar is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            if (targetDriver is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            targetDriver.AddCar(targetCar);
            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string StartRace(string raceName)
        {
            var targetRace = raceRepo.GetByName(raceName);

            if (targetRace is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (targetRace.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            var fastestOnes = targetRace.Drivers
                .OrderByDescending(x => x.Car.CalculateRacePoints(targetRace.Laps))
                .Take(3)
                .ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, fastestOnes[0].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, fastestOnes[1].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, fastestOnes[2].Name, raceName));

            this.raceRepo.Remove(targetRace);

            return sb.ToString().TrimEnd();
        }
    }
}