using System;

namespace PersonEx
{
    class Child : Person
    {
        public Child(string name, int age) : base(name, age)
        {
        }

        

        public override int Age
        {
            get { return age; }
            set { if (Age >= 0 && Age < 15)
                {
                    age = value;
                }
            }
        }

    }
}
