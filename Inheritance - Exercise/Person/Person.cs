
namespace PersonEx
{
    class Person
    {
        protected int age;
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public virtual int Age {
            get { return age; }
            set
            {
                if(age >= 0)
                {
                    age = value;
                }
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}
