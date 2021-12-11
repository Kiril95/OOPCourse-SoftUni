using System;

namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        private const int InitStamina = 60;
        //Can train only in a BoxingGym.
        public Boxer(string fullName, string motivation, int numberOfMedals) 
            : base(fullName, motivation, InitStamina, numberOfMedals)
        {
        }

        public override void Exercise()
        {
            this.Stamina += 15;

            if (this.Stamina > 100)
            {
                this.Stamina = 100;

                throw new ArgumentException("Stamina cannot exceed 100 points.");
            }
        }
    }
}