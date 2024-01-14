using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleExtension.Models
{
    public class Bus : Vehicle
    {
        private const double IncreadedBusConsumption = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption + IncreadedBusConsumption;
            TankCapacity = tankCapacity;
        }
        public string DriveBus(double distance, string something)
        {
            if (something == "DriveEmpty")
            {
                FuelConsumption -= IncreadedBusConsumption;
            }

            double total = distance * FuelConsumption;
            if (total <= FuelQuantity)
            {
                FuelQuantity -= total;
                //Car travelled 9 km
                return $"{this.GetType().Name} travelled {distance} km";
            }
            return $"{this.GetType().Name} needs refueling";

        }
    }
}
