using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private List<IGym> gyms = new List<IGym>();
        private EquipmentRepository equipmentRepo = new EquipmentRepository();

        public string AddGym(string gymType, string gymName)
        {
            IGym gym;

            if (gymType == nameof(BoxingGym))
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == nameof(WeightliftingGym))
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException("Invalid gym type.");
            }

            gyms.Add(gym);
            return $"Successfully added {gymType}.";
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment;

            if (equipmentType == nameof(BoxingGloves))
            {
                equipment = new BoxingGloves();
            }
            else if (equipmentType == nameof(Kettlebell))
            {
                equipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException("Invalid equipment type.");
            }

            equipmentRepo.Add(equipment);
            return $"Successfully added {equipmentType}.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            var targetGym = gyms.FirstOrDefault(x => x.Name == gymName);
            var targetEquipment = equipmentRepo.FindByType(equipmentType);

            if (targetEquipment is null)
            {
                throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}.");
            }

            targetGym.AddEquipment(targetEquipment);
            equipmentRepo.Remove(targetEquipment);
            return $"Successfully added {equipmentType} to {gymName}.";
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            var targetGym = gyms.FirstOrDefault(x => x.Name == gymName);
            IAthlete athlete;

            if (athleteType == nameof(Boxer))
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteType == nameof(Weightlifter))
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException("Invalid athlete type.");
            }

            if (targetGym is BoxingGym && athleteType == nameof(Boxer))
            {
                targetGym.AddAthlete(athlete);
                return $"Successfully added {athleteType} to {gymName}.";
            }
            if (targetGym is WeightliftingGym && athleteType == nameof(Weightlifter))
            {
                targetGym.AddAthlete(athlete);
                return $"Successfully added {athleteType} to {gymName}.";
            }
            else
            {
                return "The gym is not appropriate.";
            }
        }

        public string TrainAthletes(string gymName)
        {
            var targetGym = gyms.FirstOrDefault(x => x.Name == gymName);
            targetGym.Exercise();

            return $"Exercise athletes: {targetGym.Athletes.Count}.";
        }

        public string EquipmentWeight(string gymName)
        {
            var targetGym = gyms.FirstOrDefault(x => x.Name == gymName);
            var total = targetGym.Equipment.Sum(x => x.Weight);

            return $"The total weight of the equipment in the gym {gymName} is {total:f2} grams.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}