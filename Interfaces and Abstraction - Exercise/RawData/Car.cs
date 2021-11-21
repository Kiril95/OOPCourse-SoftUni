﻿using System.Collections.Generic;

namespace P01_RawData
{
    public class Car : ICargo, IEngine, ITire
    {
        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType,
            double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, 
            double tire3Pressure, int tire3Age, double tire4Pressure, int tire4Age)
        {
            this.Model = model;
            this.EngineSpeed = engineSpeed;
            this.EnginePower = enginePower;
            this.CargoWeight = cargoWeight;
            this.CargoType = cargoType;
            this.Tires = new KeyValuePair<double, int>[] 
                { 
                    KeyValuePair.Create(tire1Pressure, tire1Age), KeyValuePair.Create(tire2Pressure, tire2Age), 
                    KeyValuePair.Create(tire3Pressure, tire3Age), KeyValuePair.Create(tire4Pressure, tire4Age)
                };

        }
        public string Model { get; set; }
        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }
        public int CargoWeight { get; set; }
        public string CargoType { get; set; }
        public KeyValuePair<double, int>[] Tires { get; set; }
    }
}