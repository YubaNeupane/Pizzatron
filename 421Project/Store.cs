using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Future;
using Pizza;

namespace Stores
{
    internal abstract class Store : StoreIF
    {
        protected string storeName;
        protected double waitTime;
        
        public Store()
        {
            storeName = "";
            waitTime = 0;
        }

        public string getStoreName()
        {
            return storeName;
        }

        public double getWaitTime()
        {
            return waitTime;
        }

        public Order make(PizzaIF pizza)
        {
            return new Order();
        }
    }
}
