using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleExtension.Models
{
    public class Truck : Vehicle
    {
        private const double IncreadedTruckConsumption = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption + IncreadedTruckConsumption;
            TankCapacity = tankCapacity;

            if(FuelQuantity > TankCapacity)
            {
                FuelQuantity = 0;
            }
        }
        
        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            if (liters + FuelQuantity > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                return;
            }
            FuelQuantity += liters * 0.95;
        }
    }
}
