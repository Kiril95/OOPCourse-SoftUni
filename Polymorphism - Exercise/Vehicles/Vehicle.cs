namespace Vehicles
{
    public abstract class Vehicle
    {
        public virtual double FuelQuantity { get; set; }
        public virtual double FuelConsumptionPerKm { get; set; }

        public virtual string Drive(double distance)
        {
            return null;
        }

        public virtual void Refuel(double amount)
        {
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}