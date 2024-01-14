using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double IncreadedTruckConsumption = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption + IncreadedTruckConsumption;
        }
        
        public override void Refuel(double liters)
        {
            FuelQuantity += liters * 0.95;
        }
    }
}
