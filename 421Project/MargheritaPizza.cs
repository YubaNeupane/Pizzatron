using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza
{
    internal class MargheritaPizza : Pizza
    {
        public MargheritaPizza()
        {
            this.name = "Margherita Pizza";
            this.price = 17.50;
        }

        public override void make()
        {
            throw new NotImplementedException();
        }
    }
}
