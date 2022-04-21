using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toppings;

namespace Pizza
{
    internal class PizzaWrapper : Pizza
    {
        
        private PizzaIF pizza;
        private ToppingIF topping;

        public PizzaWrapper(PizzaIF pizza, ToppingIF topping)
        {
            this.pizza = pizza;
            this.topping = topping;
        }

        //TODO: FIX GET PRICE!
        public override double getPrice()
        {
            return base.getPrice();
        }

        //TODO: FIX MAKE!
        public override void make()
        {
            throw new NotImplementedException();
        }
    }
}
