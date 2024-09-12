using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace projectPart5
{
    internal class Seller : User, Icomparable<Seller>
    {
        private List<Product> products;
        private int itemSold = 0;
        public Seller(Seller other) : base(other)
        {
            this.products = new List<Product>();
            foreach (Product product in other.products)
            {
                this.products.Add(new Product(product));
            }
            this.itemSold = other.itemSold;
        }
        public Seller(string username, string password, Address address) : base(username, password, address)
        {
            this.products = new List<Product>();
            itemSold = 0;
        }

        public Seller(string username, string password, int itemSold, Address address) : base(username, password, address)
        {
            this.products = new List<Product>();
            this.itemSold = itemSold;
        }
        public Seller(string username, string password, int itemSold, Address address, List<Product> products) : base(username, password, address)
        {
            this.products = products;
            this.itemSold = itemSold;
        }
        public Seller() : base()
        {
            this.products = new List<Product>();
            itemSold = 0;
        }
        public static Seller operator +(Seller seller, Product product)
        {
            Seller newSeller = new Seller(seller);
            newSeller.products.Add(product);
            return newSeller;
        }
        public List<Product> Products
        {
            get { return products; }
            set { products = value; }
        }
        public int ItemSold
        {
            get { return itemSold; }
        }
        public override string ToString()
        {
            string str = base.ToString();
            foreach (Product product in products)
            {
                str += product.ToString();
            }
            str += ("Item sold :" + itemSold);
            return str;
        }
        public void AddProduct(Product p)
        {
            products.Add(p);
        }
        public override bool Equals(object obj)
        {
            Seller temp = obj as Seller;
            if (temp == null)
                return false;
            foreach (Product product in products)
            {
                if (product.Equals(temp.products))
                    return false;
            }
            return base.Equals(obj);
        }
        public void sellItem()
        {
            itemSold++;

        }
        public int comperTo(Seller other)
        {
            if (itemSold < other.ItemSold)
                return -1;
            else if (itemSold > other.ItemSold)
                return 1;
            else
                return 0;
        }
    }
}
