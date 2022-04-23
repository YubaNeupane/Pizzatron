using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace PizzaFilters
{
    internal class NoFilter : PizzaFilter
    {
        public NoFilter(List<ToppingFromFile> inputData) : base(inputData)
        {
        }

        public override List<ToppingFromFile> processTopping()
        {
            return data;
        }
    }
}
