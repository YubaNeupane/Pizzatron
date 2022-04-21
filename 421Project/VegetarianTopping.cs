namespace Toppings
{
    internal abstract class VegetarianTopping : Topping
    {
        protected double extraPrice;
        public VegetarianTopping() : base()
        {
            extraPrice = 0.75;
            typeName = "Vegetatian";
        }
        public override double getPrice()
        {
            return (isExtra ? price + extraPrice : price);
        }
    }
}
