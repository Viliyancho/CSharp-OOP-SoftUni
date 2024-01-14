using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public abstract class Animal
{
		private string name;

		public Animal(string name1)
		{
			Name = name1;
		}
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

	}

}
