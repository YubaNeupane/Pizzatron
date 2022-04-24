using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizza;
using Future;

namespace Stores
{
    internal interface StoreIF
    {
        public string getStoreName();
        public double getWaitTime();
        public Order make(User user, PizzaIF pizza);
    }
}
