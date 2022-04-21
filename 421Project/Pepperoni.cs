using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toppings
{
    internal class Pepperoni:MeatTopping
    {
        public Pepperoni() : base()
        {
            name = "Pepperoni";
            price = 1.20;
        }
    }
}
