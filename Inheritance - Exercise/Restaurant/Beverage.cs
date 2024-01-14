using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantEx
{
    public class Beverage : Product
    {
        public Beverage(string name, decimal price, double milliliters)
        : base(name, price)
        {
            Milliliters = milliliters;
        }

        public double Milliliters { get; private set; }
    }
}
