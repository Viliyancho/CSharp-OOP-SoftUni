using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Interfaces;

namespace VehicleExtension.Models
{
    public abstract class Vehicle : IVehicle
    {
        public double TankCapacity { get; protected set; }
        public double FuelQuantity { get; protected set; }

        public double FuelConsumption { get; protected set; }

        public string Drive(double distance)
        {
            double total = distance * FuelConsumption;
            if (total <= FuelQuantity)
            {
                FuelQuantity -= total;
                //Car travelled 9 km
                return $"{this.GetType().Name} travelled {distance} km";
            }
            return $"{this.GetType().Name} needs refueling";
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            if (liters + FuelQuantity > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                return;
            }
            FuelQuantity += liters;
        }
    }
}
