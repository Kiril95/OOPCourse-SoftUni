using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const string InitialRacingBehavior = "aggressive";
        private const int InitialDrivingExperience = 10;

        public StreetRacer(string username, ICar car) 
            : base(username, InitialRacingBehavior, InitialDrivingExperience, car)
        {
        }

        public override void Race()
        {
            base.Race();
            this.DrivingExperience += 5;
        }
    }
}