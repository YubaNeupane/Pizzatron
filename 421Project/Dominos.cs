using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizza;

namespace Stores
{
    internal class Dominos : Store
    {
        public Dominos()
        {
            storeName = "Dominos";
            waitTime = 30;
        }
        public override void make(PizzaIF pizza)
        {
            throw new NotImplementedException();
        }
    }
}
