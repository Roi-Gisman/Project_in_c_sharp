using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace projectPart5
{
    internal class Buyer : User
    {
        private List<Order> orders;
        private List<Product> shoppingCart;

        public Buyer(Buyer other) : base(other)
        {
            orders = new List<Order>();
            shoppingCart = new List<Product>();
            foreach (Order order in other.orders)
            {
                this.orders.Add(order);
            }
            foreach (Product products in other.shoppingCart)
            {
                this.shoppingCart.Add(new Product(products));
            }
        }
        public Buyer(string username, string password, Address address) : base(username, password, address)
        {
            orders = new List<Order>();
            shoppingCart = new List<Product>();
        }
        public Buyer() : base()
        {
            orders = new List<Order>();
            shoppingCart = new List<Product>();
        }
        public static Buyer operator +(Buyer buyer1, Buyer buyer2)
        {
            Buyer newBuyer = new Buyer();
            foreach (Order order1 in buyer1.orders)
            {
                newBuyer.Orders.Add(order1);
            }
            foreach (Order order2 in buyer2.orders)
            {
                newBuyer.Orders.Add(order2);
            }
            foreach (Product product1 in buyer1.ShoppingCart)
            {
                newBuyer.ShoppingCart.Add(product1);
            }
            foreach (Product product2 in buyer2.ShoppingCart)
            {
                newBuyer.ShoppingCart.Add(product2);
            }
            return newBuyer;
        }
        public static bool operator >(Buyer buyer1, Buyer buyer2)
        {
            float priceCart = 0;
            foreach (Order order in buyer1.orders)
            {
                priceCart += order.TotalPrice;
            }
            foreach (Order order in buyer2.orders)
            {
                priceCart -= order.TotalPrice;
            }
            if (priceCart > 0)
            {
                return true;
            }
            return false;
        }
        public static bool operator <(Buyer buyer1, Buyer buyer2)
        {
            float priceCart = 0;
            foreach (Order order in buyer1.orders)
            {
                priceCart += order.TotalPrice;
            }
            foreach (Order order in buyer2.orders)
            {
                priceCart -= order.TotalPrice;
            }
            if (priceCart > 0)
            {
                return true;
            }
            return false;
        }
        public List<Order> Orders
        {
            get { return orders; }
            set { orders = value; }
        }
        public List<Product> ShoppingCart
        {
            get { return shoppingCart; }
            set { shoppingCart = value; }
        }
        public override string ToString()
        {
            string str = base.ToString();
            int counter = 1;
            foreach (Product product in shoppingCart)
            {
                str += "PRODUCT" + counter + ". " + product.ToString() + "\n";
                counter++;
            }
            counter = 1;
            foreach (Order order in orders)
            {
                str += "ORDER" + counter + ". " + order.ToString() + "\n";
                counter++;
            }
            return str;
        }
        public void AddToCart(Product p)
        {
            if (p is Special_Packaging_Prod)
            {
                shoppingCart.Add(new Special_Packaging_Prod((Special_Packaging_Prod)p));
            }
            else
            {
                shoppingCart.Add(p);
            }
        }
        public void AddCartToCart(Order o)
        {
            orders.Add(o);
        }
        public override bool Equals(object obj)
        {
            Buyer temp = obj as Buyer;
            if (temp == null)
                return false;
            foreach (Order order in orders)
            {
                if (!orders.Equals(temp.orders))
                    return false;
            }
            foreach (Product product in shoppingCart)
            {
                if (!shoppingCart.Equals(temp.shoppingCart))
                    return false;
            }
            return base.Equals(obj);
        }
        public int GetOrdersLength()
        {
            int counter = 0;
            foreach (Order order in orders)
            {
                counter++;
            }
            return counter;
        }
        public int GetShopingCartLength()
        {
            int counter = 0;
            foreach (Product p in shoppingCart)
            {
                counter++;
            }
            return counter;
        }
    }
}
