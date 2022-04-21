using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toppings
{
    internal abstract class VegetarianTopping:Topping
    {
        protected double extraPrice;
        public VegetarianTopping():base(){
            extraPrice = 0.75;
            typeName = "Vegetatian";
        }
        public override double getPrice()
        {
            return (isExtra ? price + extraPrice : price);
        }
    }
}
