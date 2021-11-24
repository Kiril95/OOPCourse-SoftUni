using System.Collections.Generic;

namespace Mordor_sCruelPlan
{
    public class GandalfTheGrey
    {
        private Dictionary<string, int> foods = new Dictionary<string, int>()
        {
            ["cram"] = 2,
            ["lembas"] = 3,
            ["apple"] = 1,
            ["melon"] = 1,
            ["honeycake"] = 5,
            ["mushrooms"] = -10,
        };
        private int gandalfMoodPoints;
        public GandalfTheGrey()
        {
            this.GandalfMoodPoints = 0;
        }
        public int GandalfMoodPoints { get; set; } 

        public void Eat(string food)
        {
            food = food.ToLower();
            if (foods.ContainsKey(food))
            {
                this.GandalfMoodPoints += foods[food];
            }
            else
            {
                this.GandalfMoodPoints--;
            }
        }

        public string CalculateMood()
        {
            if (this.GandalfMoodPoints > 15)
            {
                return "JavaScript";
            }

            if (this.GandalfMoodPoints >= 1)
            {
                return "Happy";
            }

            if (this.GandalfMoodPoints >= -5)
            {
                return "Sad";
            }

            return "Angry";
        }
    }
}