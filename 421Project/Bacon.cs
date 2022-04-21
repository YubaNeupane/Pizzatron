using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topping
{
    internal class Bacon:MeatTopping
    {
        public Bacon() : base()
        {
            name = "Bacon";
            price = 1.00;
        }
    }
}
