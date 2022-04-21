using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza
{
    internal abstract class Pizza : PizzaIF
    {
        protected double price;
        protected string name = "";

        public Pizza()
        {
            price = 0;
            name = "";
        }

        public string getName()
        {
            return name;
        }

        public double getPrice()
        {
            return price;
        }

        public abstract void make();
    }
}
