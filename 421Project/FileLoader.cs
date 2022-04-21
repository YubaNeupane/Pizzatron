using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    internal class FileLoader
    {

        public List<ToppingFromFile> getToppingsFromFile()
        {
            List<ToppingFromFile> toppings = new List<ToppingFromFile>();
            foreach(string line in File.ReadLines("Toppings.txt"))
            {
                String[] data= line.Split(',');

                ToppingFromFile toppingFromFile = new ToppingFromFile();
                toppingFromFile.type = new List<string>();

                toppingFromFile.Name = data[0];
                try
                {
                    toppingFromFile.price = Double.Parse(data[1]);
                }
                catch (Exception)
                {
                    Debug.WriteLine("Error: price for topping not casting to double");
                }

                for(int i = 2;i < data.Length; i++)
                {
                    toppingFromFile.type.Add(data[i]);
                }
                toppings.Add(toppingFromFile);
            }
            return toppings;
        }

        public List<PizzaBaseFromFile> getPizzaBaseFromFile()
        {
            List<PizzaBaseFromFile> pizzas = new List<PizzaBaseFromFile>();
            foreach (string line in File.ReadLines("PizzaBase.txt"))
            {
                String[] data = line.Split(',');
                PizzaBaseFromFile pizzaBaseFromFile = new PizzaBaseFromFile();
                pizzaBaseFromFile.Name = data[0];
                pizzaBaseFromFile.price = Double.Parse(data[1]);
                pizzas.Add(pizzaBaseFromFile);
            }

            return pizzas;
        }

    }
}
