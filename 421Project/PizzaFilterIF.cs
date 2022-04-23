using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace PizzaFilters
{
    internal interface PizzaFilterIF
    {
        public List<ToppingFromFile> processTopping();
        public List<ToppingFromFile> getData();
    }
}
