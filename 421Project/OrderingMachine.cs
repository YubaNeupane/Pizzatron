using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using Pizza;
using Toppings;
using PizzaFilters;
using Stores;

namespace MainProgram
{
    internal class OrderingMachine
    {
        private List<ToppingFromFile> toppingFromFiles;
        private List<PizzaBaseFromFile> pizzaBaseFromFile;
        private int currentSelectedPizzaBase = -1;
        private PizzaIF? currentPizza;
        private ToppingFactory toppingFactory;
        private PizzaFilterIF toppingFilter;
        private Dictionary<string, StoreIF> stores = new Dictionary<string, StoreIF>();
        private StoreIF? selectedStore;

        public OrderingMachine()
        {
            FileLoader fileLoader = new FileLoader();
            toppingFromFiles =  fileLoader.getToppingsFromFile();
            pizzaBaseFromFile = fileLoader.getPizzaBaseFromFile();
            toppingFactory = new ToppingFactory();
            toppingFilter = new NoFilter(toppingFromFiles);

            
            stores.Add("Pizza Hut", new PizzaHut());
            stores.Add("Papa Johns", new PapaJohns());
            stores.Add("Dominos", new Dominos());
        }

        public StoreIF? selectStore(string storeName)
        {
            if (stores.ContainsKey(storeName))
            {
                selectedStore = stores[storeName];
            }
            return selectedStore;
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

        private string splitName(string name)
        {
            string[] splitPizzaName = name.Split(" ");
            name = "";
            foreach (string s in splitPizzaName)
            {
                name += s;
            }
            return name;
        }

        public void createPizza(string pizzaName)
        {
            pizzaName = splitName(pizzaName);
            Type? type = Type.GetType("Pizza." + pizzaName);
            if (type != null)
            {
                currentPizza = (PizzaIF?)Activator.CreateInstance(type);
            }
            else
            {
                currentPizza = null;
            }
        }


        public List<ToppingFromFile> getFilteredToppings(string filterType)
        {
            switch (filterType)
            {
                case "Meat":
                    toppingFilter = new MeatOnlyFilter(toppingFilter);
                    break;
                case"Vegetarian":
                    toppingFilter = new VegetarianOnlyFilter(toppingFilter);
                    break;
                case "Vegan":
                    toppingFilter = new VeganOnlyFilter(toppingFilter);
                    break;
               default:
                    toppingFilter = new NoFilter(toppingFromFiles);
                    break;
            }
            return toppingFilter.processTopping();
        }


        public void addTopingToPizza(string toppingName, bool isExtra)
        {
            toppingName = splitName(toppingName);

            ToppingIF? topping = toppingFactory.getTopping(toppingName);
            topping?.setIsExtra(isExtra);
            if (topping != null && currentPizza != null)
            {
                currentPizza = new PizzaWrapper(currentPizza, topping);
            }
        }
        public double[] getPrice()
        {
            double[]? price = new double[3];

            if(currentPizza != null)
            {
                price[0] = currentPizza.getPrice();
                price[1] = price[0] * 0.07;
                price[2] = price[0] + price[1];
            }

            return price;
        }

    }
}
