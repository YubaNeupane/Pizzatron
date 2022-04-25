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
        public DateTime date;
        public List<String> toppings;
        public  Order(User user, PizzaIF pizza, List<String> toppings)
        {
            this.user = user;
            this.pizza = pizza;
            date = DateTime.Now;
            this.toppings = toppings;
        }
    }
}
