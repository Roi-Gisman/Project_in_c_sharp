using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace projectPart5
{
    internal class Order
    {
        private string username;
        private Address address;
        List<Product> shoppingCart;
        private float totalPrice;
        public Order(string username, Address address, List<Product> shoppingCart, float totalPrice)
        {
            this.username = username;
            this.address = address;
            this.shoppingCart = shoppingCart;
            this.totalPrice = totalPrice;
        }
        public Order()
        {
            username = "";
            address = new Address();
            shoppingCart = new List<Product>();
            totalPrice = 0;
        }
        public Order(Order other)
        {
            this.username = other.username;
            this.address = other.address;
            this.shoppingCart = other.shoppingCart;
            this.totalPrice = other.totalPrice;
        }

        public string Username
        {
            get { return username; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Username cannot be empty.");
                }
                username = value;
            }
        }
        public Address Address
        {
            get { return address; }
            set { address = value; }
        }
        public List<Product> ShoppingCart
        {
            get { return shoppingCart; }
            set { shoppingCart = value; }
        }
        public float TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }
        public override string ToString()
        {
            int counter = 1;
            string str = "Username: " + username + "\nAddress: " + address.ToString() + "\nOrder:\n";
            foreach (Product product in shoppingCart)
            {
                str += (counter + 1) + ". " + shoppingCart.ToString() + "\n";
                counter++;
            }
            return str;
        }
        public override bool Equals(object obj)
        {
            Order temp = obj as Order;
            if (temp == null)
                return false;
            foreach (Product product in shoppingCart)
            {
                if (shoppingCart.Equals(temp.shoppingCart))
                    return false;
            }
            return username.Equals(temp.username) && (totalPrice == temp.totalPrice) && address.Equals(temp.address);

        }
    }
}
