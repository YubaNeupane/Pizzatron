using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace PizzaFilters
{
    internal class MeatOnlyFilter : PizzaFilter
    {
        public MeatOnlyFilter(PizzaFilterIF pizza) : base(pizza)
        {
        }

        public override List<ToppingFromFile> processTopping()
        {
            List<ToppingFromFile> returnToppings = new List<ToppingFromFile>();
            foreach(ToppingFromFile topping in data)
            {
                foreach(String s in topping.type)
                {
                    if (s == "Meat")
                    {
                        returnToppings.Add(topping);
                        break;
                    }
                }
              
            }
            return returnToppings;
        }
    }
}
