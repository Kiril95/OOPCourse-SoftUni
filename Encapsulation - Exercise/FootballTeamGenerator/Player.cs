using System;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        public Player(string name, Stats stats)
        {
            Name = name;
            Stats = stats;
        }
        public string Name
        {
            get => name; 

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }
        public Stats Stats { get; set; }
        public int PlayerAverageStats()
        {
            return (int)Math.Round((this.Stats.Dribble + this.Stats.Endurance + this.Stats.Passing + this.Stats.Shooting + this.Stats.Sprint) / 5.0);
        }

    }
}
