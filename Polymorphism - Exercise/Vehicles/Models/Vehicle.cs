using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
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
            FuelQuantity += liters;
        }
    }
}
