using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stores;
using Pizza;

namespace Future
{
    internal class OrderFuture
    {
        private StoreIF store;
        private PizzaIF pizza;
        AsynchronousFuture futureSupport;
        public OrderFuture(StoreIF store, PizzaIF pizza)
        {
            this.store = store;
            this.pizza = pizza;
            futureSupport= new AsynchronousFuture();
            new Thread(run).Start();
        }

        public void run()
        {
            try
            {
                Order info = store.make(pizza);
            }
            catch (Exception)
            {
                
            }
        }
    }
}
