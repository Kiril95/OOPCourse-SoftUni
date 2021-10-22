using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> roster;
        public Team(string name)
        {
            Name = name;
            Roster = new List<Player>();
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
        public List<Player> Roster { get; private set; }

        public int TeamRating()
        {
            var total = 0;

            foreach (var player in Roster)
            {
                total += player.PlayerAverageStats();
            }
            if (total != 0)
            {
                return (int)Math.Round(total / (double)Roster.Count);
            }

            return total;
        }
        public void AddPlayer(Player player)
        {
            this.Roster.Add(player);
        }

        public void RemovePlayer(string player)
        {
            if (!this.Roster.Any(x => x.Name == player))
            {
                throw new ArgumentException($"Player {player} is not in {this.Name} team.");
            }

            Player target = this.Roster.FirstOrDefault(x => x.Name == player);
            this.Roster.Remove(target);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TeamRating()}";
        }
    }
}
