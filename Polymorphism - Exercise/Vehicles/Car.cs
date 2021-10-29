namespace Vehicles
{
    public class Car : Vehicle
    {
        public sealed override double FuelQuantity { get; set; }
        public sealed override double FuelConsumptionPerKm { get; set; }

        public Car(double fuelQuantity, double fuelConsumptionPerKm)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
        }
        public override string Drive(double distance)
        {
            if (FuelQuantity - (FuelConsumptionPerKm + 0.9) * distance >= 0)
            {
                FuelQuantity -= (FuelConsumptionPerKm + 0.9) * distance;
                return $"Car travelled {distance} km";
            }

            return "Car needs refueling";
        }

        public override void Refuel(double amount)
        {
            FuelQuantity += amount;
        }

    }
}