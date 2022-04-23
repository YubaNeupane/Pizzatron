using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizza;

namespace Stores
{
    internal interface StoreIF
    {
        public string getStoreName();
        public double getWaitTime();
        public void make(PizzaIF pizza);
    }
}
