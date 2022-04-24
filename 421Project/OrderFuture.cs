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
        ToolStripProgressBar miniProgressBar;
        public OrderFuture(StoreIF store, PizzaIF pizza, ProgressBar pbar, ToolStripProgressBar miniProgressBar)
        {
            this.store = store;
            this.pizza = pizza;
            this.progressBar = pbar;
            this.miniProgressBar = miniProgressBar;
            futureSupport = new AsynchronousFuture();
            new Thread(run).Start();
        }

        public void run()
        {
            try
            {
                MethodInvoker mi = new MethodInvoker(() => progressBar.Value += 1);
                MethodInvoker mi2 = new MethodInvoker(() => miniProgressBar.Value = progressBar.Value);
                while (true)
                {
                    if (progressBar.Value >= 100) break;
                    if (progressBar.InvokeRequired && miniProgressBar.GetCurrentParent().InvokeRequired)
                    {
                        progressBar.Invoke(mi);
                        miniProgressBar.GetCurrentParent().Invoke(mi2);
                    }
                    else
                    {
                        mi.Invoke();
                        mi2.Invoke();
                    }

                    Thread.Sleep((int)(store.getWaitTime()*50));
                }
            

                Order info = store.make(pizza);

            }
            catch (Exception)
            {
                
            }
        }
    }
}
