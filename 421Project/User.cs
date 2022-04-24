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
        private string Name { get; }
        private string Address { get; }
        private string PhoneNumber { get; }
        private string CardNumber { get; }
        private string CVC { get; }
        private Store store;

        public User(string name, string address, string phoneNumber, string cardNumber, string cvc, Store store)
        {
            this.Name = name;
            this.Address = address;
            this.CardNumber = cardNumber;
            this.CVC = cvc;
            this.PhoneNumber = phoneNumber;
            this.store = store;
        }
        public OrderFuture getOrder(PizzaIF pizza)
        {
            lock (this)
            {
                return new OrderFuture(store, pizza);
            }
        }
    }
}
