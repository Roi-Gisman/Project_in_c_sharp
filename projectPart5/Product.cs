using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectPart5
{
    internal class Product
    {
        protected string productName;
        protected int serialNumber;
        protected static int counter = 1;
        protected float price;
        public enum category
        {
            Children = 1, electricity = 2, office = 3, clothing = 4
        }
        protected category type;

        public Product(string productName, float price, category type)
        {
            ProductName = productName;
            serialNumber = counter++;
            Type = type;
            this.price = price;
        }
        public Product(string productName, int serialNumber, float price, category type)
        {
            ProductName = productName;
            this.serialNumber = serialNumber;
            counter = serialNumber + 1;
            Type = type;
            this.price = price;
        }
        public Product()
        {
            productName = "";
            serialNumber = counter++;
            type = category.Children;
            this.price = 0;

        }
        public Product(Product other)
        {
            type = other.type;
            productName = other.productName;
            serialNumber = other.serialNumber;
            price = other.price;
        }

        public string ProductName
        {
            get { return productName; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("The name cannot be empty.");
                }
                productName = value;
            }
        }
        public category Type
        {
            get { return type; }
            set { type = value; }
        }
        public int SerialNumber
        {
            get { return serialNumber; }
            set { value = serialNumber; }
        }
        public float Price
        {
            get { return price; }
            set
            {
                if (value == null)
                    throw new ArgumentException("You did not enter a price");
                price = value;
            }
        }
        public override string ToString()
        {
            return "product serial number: " + this.serialNumber + "  product name is: " + this.productName + "price: " + this.price + "  product type is: " + this.type;
        }
        public override bool Equals(object obj)
        {
            Product temp = obj as Product;
            if (temp == null)
                return false;
            return productName.Equals(temp.productName) && (serialNumber == temp.serialNumber) && (type == temp.type) && (price == temp.price);
        }
    }
}
