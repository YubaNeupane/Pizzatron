using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizza;

namespace  Stores
{
    internal class PapaJohns : Store
    {
        public PapaJohns()
        {
            storeName = "Papa Johns";
            waitTime = 5;
        }

        public override void make(PizzaIF pizza)
        {
            throw new NotImplementedException();
        }
    }
}
