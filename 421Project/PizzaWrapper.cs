using System.Diagnostics;
using Toppings;

namespace Pizza
{
    internal class PizzaWrapper : Pizza
    {

        private PizzaIF pizza;
        private ToppingIF topping;

        public PizzaWrapper(PizzaIF pizza, ToppingIF topping)
        {
            this.name = pizza.getName();
            this.pizza = pizza;
            this.topping = topping;
        }

        public override double getPrice()
        {
            return pizza.getPrice() + topping.getPrice();
        }

        public string getToppingsNames()
        {
            return pizza.getName() + topping.getName();

        }

        public override void make()
        {
            Debug.WriteLine("Making Pizza...");
        }
    }
}
