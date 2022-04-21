using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza
{
    internal class PestoPizza : Pizza
    {
        public PestoPizza()
        {
            this.name = "Pesto Pizza";
            this.price = 11.49;
        }

        public override void make()
        {
            throw new NotImplementedException();
        }
    }
}
