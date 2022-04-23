using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using Pizza;

namespace MainProgram
{
    internal class OrderingMachine
    {
        private List<ToppingFromFile> toppingFromFiles;
        private List<PizzaBaseFromFile> pizzaBaseFromFile;
        private int currentSelectedPizzaBase = -1;
        private PizzaIF? currentPizza;

        public OrderingMachine()
        {
            FileLoader fileLoader = new FileLoader();
            toppingFromFiles =  fileLoader.getToppingsFromFile();
            pizzaBaseFromFile = fileLoader.getPizzaBaseFromFile();
        }

        public List<ToppingFromFile> getToppingFromFile()
        {
            return toppingFromFiles;
        }
        public List<PizzaBaseFromFile> getPizzaBaseFromFile()
        {
            return pizzaBaseFromFile;
        }

        public void setSelectedPizzaBase(int index)
        {
            currentSelectedPizzaBase = index;
        }

        public int GetCurrentSelectedPizzaBase()
        {
            return currentSelectedPizzaBase;
        }
        public PizzaBaseFromFile getSelctedPizzaBase()
        {
             return pizzaBaseFromFile[currentSelectedPizzaBase];
        }

        public void createPizza(string pizzaName)
        {
            string[] splitPizzaName = pizzaName.Split(" ");
            pizzaName = "";
            foreach(string s in splitPizzaName)
            {
                pizzaName += s;
            }
            Type? type = Type.GetType("Pizza." + pizzaName);
            if (type != null)
            {
                currentPizza = (PizzaIF?)Activator.CreateInstance(type);
            }
        }

    }
}
