using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantEx
{
    public class Cake : Dessert
    {
        private const double DefaultGrams = 250;
        private const double DefaultCalories = 1000;
        private const decimal CakePrice = 5m;
        public Cake(string name) : base(name, CakePrice, DefaultGrams, DefaultCalories)
        {
        }
    }
}
