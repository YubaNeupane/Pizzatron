using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topping
{
    internal abstract class Topping : ToppingIF
    {
        protected string name = "";
        protected double price;
        protected string typeName = "";
        protected bool isExtra;

        public Topping()
        {
            this.name = "";
            this.price = 0;
            this.typeName = "";
            this.isExtra = false;
        }

        public string getName()
        {
            return name;
        }

        public abstract double getPrice();

        public string getTypeName()
        {
            return typeName;
        }

        public void setIsExtra(bool isExtra)
        {
            this.isExtra=isExtra;
        }
    }
}
