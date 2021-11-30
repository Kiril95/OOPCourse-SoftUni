using System;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double InitialAvailableFuel = 80;
        private const double ConsumptionPerRace = 10;

        public TunedCar(string make, string model, string vin, int horsePower) 
            : base(make, model, vin, horsePower, InitialAvailableFuel, ConsumptionPerRace)
        {
        }

        public override void Drive()
        {
            this.HorsePower -= (int)Math.Round(this.HorsePower * 0.03);
            base.Drive();
        }
    }
}