using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private List<IEquipment> equipments = new List<IEquipment>();
        private List<IAthlete> athletes = new List<IAthlete>();

        protected Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Gym name cannot be null or empty.");
                }

                this.name = value;
            }
        }
        public int Capacity { get; private set; }
        public double EquipmentWeight => this.equipments.Sum(x => x.Weight);
        public ICollection<IEquipment> Equipment => this.equipments;
        public ICollection<IAthlete> Athletes => this.athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Capacity <= athletes.Count)
            {
                throw new InvalidOperationException("Not enough space in the gym.");
            }

            this.athletes.Add(athlete);
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return this.athletes.Remove(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.equipments.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var person in athletes)
            {
                person.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} is a {GetType().Name}:");
            sb.AppendLine($"Athletes: {(athletes.Any() ? string.Join(", ", Athletes.Select(x => x.FullName)) : "No athletes")}");
            sb.AppendLine($"Equipment total count: {this.Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {this.Equipment.Sum(x => x.Weight):f2} grams");
            
            return sb.ToString().TrimEnd();
        }
    }
}