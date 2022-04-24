using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizza;
using Stores;

namespace Future
{
    internal class User
    {
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string CardNumber { get; set; } = "";
        public string CVC { get; set; } = "";

        public User()
        {
            
        }


        public OrderFuture getOrder(StoreIF store ,PizzaIF pizza, User currentUser,ProgressBar progress, ToolStripProgressBar miniProgressBar)
        {
            lock (this)
            {
                return new OrderFuture(store, pizza, progress, miniProgressBar, currentUser);
            }
        }
    }
}
