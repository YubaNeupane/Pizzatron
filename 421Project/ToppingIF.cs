using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topping
{
    public interface ToppingIF
    {
        public double getPrice();
        public string getTypeName();
        public string getName();
        public void setIsExtra(bool isExtra);


    }
}
