using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace PizzaFilters
{
    internal abstract class PizzaFilter : PizzaFilterIF
    {
        protected List<ToppingFromFile> data;

        public PizzaFilter(List<ToppingFromFile> inputData)
        {
            data = inputData;
        }
        public PizzaFilter(PizzaFilterIF pizza)
        {
            data = pizza.getData();
        }

        public List<ToppingFromFile> getData()
        {
            return data;
        }

        public abstract List<ToppingFromFile> processTopping();


    }
}
