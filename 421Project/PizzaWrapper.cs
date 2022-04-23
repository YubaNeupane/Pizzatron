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

        public override double getPrice()
        {
            return pizza.getPrice() + topping.getPrice();
        }

        //TODO: FIX MAKE!
        public override void make()
        {
            throw new NotImplementedException();
        }
    }
}
