using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topping
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
