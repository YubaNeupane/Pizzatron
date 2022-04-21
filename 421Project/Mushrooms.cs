using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topping
{
    internal class Mushrooms:VegetarianTopping
    {
        public Mushrooms():base()
        {
            name = "Mushrooms";
            price = 0.75;
        }
    }
}
