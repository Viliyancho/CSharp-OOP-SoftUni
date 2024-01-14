using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Topping
    {
        private const double BaseToppingCaloriesPerGram = 2;
        private readonly Dictionary<string, double> ToppingTypesCalories;

        private string type;

        private double weight;

        public Topping(string type, double weight)
        {
            ToppingTypesCalories = new Dictionary<string, double>()
            { { "meat", 1.2 }, { "veggies", 0.8 }, { "cheese", 1.1 }, { "sauce", 0.9 } };
            Type = type;
            Weight = weight;
        }

        public string Type
        {
            get { return type; }
            private set
            {
                if (!ToppingTypesCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
        }

        public double Weight
        {
            get { return weight; }
            private set
            {
                if(value<1 || value > 50)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }

        public double Calories
        {
            get
            {
                return BaseToppingCaloriesPerGram * Weight * ToppingTypesCalories[Type.ToLower()];
            }
        }

    }
}
