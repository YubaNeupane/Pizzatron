namespace Toppings
{
    internal abstract class MeatTopping : Topping
    {
        protected double extraPrice;
        public MeatTopping() : base()
        {
            extraPrice = 1.25;
            typeName = "Meat";
        }
        public override double getPrice()
        {
            return (isExtra ? price + extraPrice : price);
        }
    }
}
