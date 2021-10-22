using System;

namespace FootballTeamGenerator
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }
        public int Shooting
        {
            get => shooting; 

            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{GetType().GetProperty("Shooting").Name} should be between 0 and 100.");
                }

                shooting = value;
            }
        }

        public int Passing
        {
            get => passing; 

            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{GetType().GetProperty("Passing").Name} should be between 0 and 100.");
                }

                passing = value;
            }
        }

        public int Dribble
        {
            get => dribble; 

            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{GetType().GetProperty("Dribble").Name} should be between 0 and 100.");
                }

                dribble = value;
            }
        }

        public int Sprint
        {
            get => sprint; 

            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{GetType().GetProperty("Sprint").Name} should be between 0 and 100.");
                }

                sprint = value;
            }
        }

        public int Endurance
        {
            get => endurance; 

            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{GetType().GetProperty("Endurance").Name} should be between 0 and 100.");
                }

                endurance = value;
            }
        }
    }
}
