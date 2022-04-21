using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza
{
    public interface PizzaIF
    {
        public double getPrice();
        public string getName();
        public void make();
    }
}
