namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const int InitialCubicCentimeters = 5000;
        private const int MinHorsePower = 400;
        private const int MaxHorsePower = 600;

        public MuscleCar(string model, int horsePower) 
            : base(model, horsePower, InitialCubicCentimeters, MinHorsePower, MaxHorsePower)
        {
        }
    }
}