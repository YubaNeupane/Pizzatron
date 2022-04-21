using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace MainProgram
{
    internal class OrderingMachine
    {
        List<ToppingFromFile> toppingFromFiles;
        List<PizzaBaseFromFile> pizzaBaseFromFile;

        public OrderingMachine()
        {
            FileLoader fileLoader = new FileLoader();
            toppingFromFiles =  fileLoader.getToppingsFromFile();
            pizzaBaseFromFile = fileLoader.getPizzaBaseFromFile();
        }
    }
}
