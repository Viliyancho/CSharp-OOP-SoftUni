using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleExtension.Models
{
    public class Car : Vehicle
    {
        private const double IncreadedCarConsumption = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption + IncreadedCarConsumption;
            TankCapacity = tankCapacity;
        }
    }
}
