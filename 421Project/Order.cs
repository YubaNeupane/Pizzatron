using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizza;

namespace Future
{
    internal class Order
    {
        public User user;
        public PizzaIF pizza;
        public  Order(User user, PizzaIF pizza)
        {
            this.user = user;
            this.pizza = pizza;
        }
    }
}
