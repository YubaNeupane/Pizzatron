using Toppings;

namespace MainProgram
{
    internal class ToppingFactory
    {
        public ToppingIF? getTopping(string toppingName)
        {
            Type? type = Type.GetType("Toppings."+toppingName);
            if(type != null)
            {
                return (ToppingIF?)Activator.CreateInstance(type);
            }
            return null;
        }
    }
}
