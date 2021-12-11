using System;

namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        private const int InitStamina = 50;
        //Can train only in a WeightliftingGym.
        public Weightlifter(string fullName, string motivation, int numberOfMedals) 
            : base(fullName, motivation, InitStamina, numberOfMedals)
        {
        }

        public override void Exercise()
        {
            this.Stamina += 10;

            if (this.Stamina > 100)
            {
                this.Stamina = 100;

                throw new ArgumentException("Stamina cannot exceed 100 points.");
            }
        }
    }
}