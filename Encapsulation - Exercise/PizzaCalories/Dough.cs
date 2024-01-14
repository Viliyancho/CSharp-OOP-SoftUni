using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Dough
    {
        private const double BaseDoughCaloriesPerGram = 2;
        private readonly Dictionary<string, double> flourTypesCalories;
        private readonly Dictionary<string, double> bakingTechniquesCalories;

        private string flourType;

        private string bakingTechnique;

        private double weight;
        public Dough(string flourType, string bakingTechnique, double weight)
        {
            flourTypesCalories = new Dictionary<string, double>() { { "white", 1.5 }, { "wholegrain", 1.0 } };
            bakingTechniquesCalories =
            new Dictionary<string, double> { { "crispy", 0.9 }, { "chewy", 1.1 }, { "homemade", 1.0 } };

            FlourType = flourType.ToLower();
            BakingTechnique = bakingTechnique.ToLower();
            Weight = weight;
        }

        public double Weight
        {
            get { return weight; }
            private set
            {
                if(value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }


        public string FlourType
        {
            get { return flourType; }
            private set
            {
                if (!flourTypesCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value;
            }
        }

        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set { bakingTechnique = value; }
        }

        public double Calories
        {
            get
            {
                return BaseDoughCaloriesPerGram * flourTypesCalories[this.FlourType]
                    * bakingTechniquesCalories[this.BakingTechnique] * Weight;
            }
        }
    }
}
