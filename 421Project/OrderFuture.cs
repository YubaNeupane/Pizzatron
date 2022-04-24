using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stores;
using Pizza;
using System.Diagnostics;

namespace Future
{
    internal class OrderFuture
    {
        private StoreIF store;
        private PizzaIF pizza;
        int progress = 0;
        AsynchronousFuture futureSupport;
        ProgressBar progressBar;
        public OrderFuture(StoreIF store, PizzaIF pizza, ProgressBar pbar)
        {
            this.store = store;
            this.pizza = pizza;
            this.progressBar = pbar;
            futureSupport= new AsynchronousFuture();
            new Thread(run).Start();
        }

        public void run()
        {
            try
            {
                MethodInvoker mi = new MethodInvoker(() => progressBar.Value = 50);
                if (progressBar.InvokeRequired)
                {
                    progressBar.Invoke(mi);
                }
                else
                {
                    mi.Invoke();
                }

                Order info = store.make(pizza);

            }
            catch (Exception)
            {
                
            }
        }
    }
}
