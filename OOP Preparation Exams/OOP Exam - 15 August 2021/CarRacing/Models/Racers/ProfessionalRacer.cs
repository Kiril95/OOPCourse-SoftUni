using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const string InitialRacingBehavior = "strict";
        private const int InitialDrivingExperience = 30;

        public ProfessionalRacer(string username, ICar car) 
            : base(username, InitialRacingBehavior, InitialDrivingExperience, car)
        {
        }

        public override void Race()
        {
            base.Race();
            this.DrivingExperience += 10;
        }
    }
}