﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShortage
{
    public interface IBuyer
    {
        string Name { get; }
        int Age { get; }
        public int Food { get; }
        void BuyFood();
    }
}