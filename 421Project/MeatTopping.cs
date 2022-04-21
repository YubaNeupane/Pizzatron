using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toppings
{
    internal abstract class MeatTopping : Topping
    {
        protected double extraPrice;
        public MeatTopping() : base()
        {
            extraPrice = 1.25;
            typeName = "Meat";
        }
        public override double getPrice()
        {
            return (isExtra ? price + extraPrice : price);
        }
    }
}
