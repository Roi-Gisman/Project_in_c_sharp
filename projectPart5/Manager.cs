using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static projectPart5.Product;

namespace projectPart5
{
    internal class Manager
    {
        private string name;
        private List<Buyer> buyers;
        private List<Seller> sellers;
        public Manager()
        {
            buyers = new List<Buyer>();
            sellers = new List<Seller>();
        }
        public Manager(string name)
        {
            this.name = name;
            buyers = new List<Buyer>();
            sellers = new List<Seller>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public List<Buyer> Buyers
        {
            get { return buyers; }
            set { buyers = value; }
        }
        public List<Seller> Sellers
        {
            get { return sellers; }
            set { sellers = value; }
        }

        public bool AddBuyer(string username, string password, string street, string city, string state, int buildingNum)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(street) || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(state) || buildingNum <= 0)
            {
                return false;
            }
            if (IsExistUsername(username))
            {
                return false;
            }
            Address address = new Address(state, city, street, buildingNum);
            buyers.Add(new Buyer(username, password, address));
            return true;
        }

        public bool AddSeller(string username, string password, string street, string city, string state, int buildingNum)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(street) || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(state) || buildingNum <= 0)
            {
                return false;
            }
            if (IsExistUsername(username))
            {
                return false;
            }
            Address address = new Address(state, city, street, buildingNum);
            sellers.Add(new Seller(username, password, address));
            return true;
        }
        public Buyer IsExistBuyer(string username, string password)
        {
            foreach (Buyer buyer in buyers)
            {
                if (buyer.Username.Equals(username) && buyer.Password.Equals(password))
                {
                    return buyer;
                }
            }
            return null;
        }
        public Seller IsExistSeller(string username, string password)
        {
            foreach (Seller seller in sellers)
            {
                if (seller.Username.Equals(username) && seller.Password.Equals(password))
                {
                    return seller;
                }
            }
            return null;
        }
        public bool IsExistUsername(string username)
        {
            foreach (Buyer buyer in buyers)
            {
                if (buyer.Username.Equals(username))
                {
                    return true;
                }
            }
            foreach (Seller seller in sellers)
            {
                if (seller.Username.Equals(username))
                {
                    return true;
                }
            }
            return false;
        }
        public void printBuyers()
        {
            foreach (Buyer buyer in buyers)
            {
                Console.WriteLine(buyer.ToString());
            }

        }

        public void printsellers()
        {
            try
            {
                sellers.Sort();
            }
            catch (Exception e)
            {
                throw new Exception("The system can't print sellers");
            }
            foreach (Seller seller in sellers)
            {
                Console.WriteLine(seller.ToString());
            }
        }
        public bool addProductToSeller(string userName, string productName, float price, Product.category type)
        {
            foreach (Seller seller in sellers)
            {
                if (seller.Username == userName)
                {
                    Product product = new Product(productName, price, type);
                    seller.AddProduct(product);
                    return true;
                }
            }
            return false;
        }

        public bool addPackagingProductToSeller(string userName, string productName, float price, Product.category type, float pacagingPrice)
        {
            foreach (Seller seller in sellers)
            {
                if (seller.Username == userName)
                {
                    Product product = new Special_Packaging_Prod(productName, price, type, pacagingPrice);
                    seller.AddProduct(product);
                    return true;
                }
            }
            return false;
        }

        public float payment(string buyerName)
        {
            if (buyerName == null || buyerName == "")
            {
                throw new Exception("The name is empty");
            }
            float priceCart = 0;
            int counterProduct = 0;
            foreach (Buyer buyer in buyers)
            {
                if (buyerName == buyer.Username)
                {
                    foreach (Product product in buyer.ShoppingCart)
                    {
                        priceCart += product.Price;
                        counterProduct++;
                    }

                    if (counterProduct < 2)
                    {
                        throw new Exception("The cart must contain more than one product");
                    }
                    foreach (Product productBuyer in buyer.ShoppingCart)
                    {
                        foreach (Seller seller in sellers)
                        {
                            foreach (Product productSeller in seller.Products)
                            {
                                if (productBuyer.ProductName == productSeller.ProductName)
                                {
                                    seller.sellItem();
                                }
                            }
                        }
                    }
                }
                Order order = new Order(buyer.Username, buyer.Address, buyer.ShoppingCart, priceCart);
                buyer.AddCartToCart(order);
                return priceCart;
            }
            return priceCart;
        }

        public bool addProductToCart(Product productName, string buyerName)
        {
            foreach (Buyer buyer in buyers)
            {
                if (buyerName == buyer.Username)
                {
                    buyer.AddToCart(productName);
                    return true;
                }
            }
            throw new Exception("this product hasnt added to the shoppingCart");
        }

        public bool is_product_exist(string productName, out Product product, out bool ispackaging, out float packagingprice)
        {
            foreach (Seller seller in sellers)
            {
                foreach (Product sellerProduct in seller.Products)
                {
                    if (productName == sellerProduct.ProductName)
                    {
                        product = sellerProduct;
                        if (sellerProduct is Special_Packaging_Prod)
                        {
                            ispackaging = true;
                            packagingprice = ((Special_Packaging_Prod)sellerProduct).PackingPrice;
                        }
                        else
                        {
                            ispackaging = false;
                            packagingprice = 0;
                        }
                        return true;
                    }
                }
            }
            ispackaging = false;
            packagingprice = 0;
            product = null;
            throw new Exception("no one sells this product,to see products avaliable press 7 on the menu. returning to menu...");
        }
        public void PrintBuyer(string buyerName)
        {
            int counter = 0;
            foreach (Buyer buyer in buyers)
            {
                if (buyerName == buyer.Username)
                {
                    foreach (Order order in buyer.Orders)
                    {
                        Console.WriteLine("order number :" + counter++);
                        order.ToString();
                    }
                }
            }
        }
        public void CreateNewCartFromOldCart(string buyerName, int num)
        {
            int counter = 0;
            if (buyerName == null || buyerName == "")
            {
                throw new Exception("The name is empty");
            }
            foreach (Buyer buyer in buyers)
            {
                if (buyerName == buyer.Username)
                {
                    foreach (Order order in buyer.Orders)
                    {
                        counter++;
                        if (counter == num)
                        {
                            foreach (Product product in order.ShoppingCart)
                            {
                                buyer.ShoppingCart.Add(product);
                            }
                        }
                    }
                }
            }
        }
        public void SaveFile()
        {
            try
            {
                StreamWriter sw = new StreamWriter(@"..\..\sellerFile.txt", false);
                foreach (Seller seller in sellers)
                {
                    sw.WriteLine(seller.Username);
                    sw.WriteLine(seller.Password);
                    sw.WriteLine(seller.ItemSold);
                    sw.WriteLine(seller.Address.State);
                    sw.WriteLine(seller.Address.City);
                    sw.WriteLine(seller.Address.Street);
                    sw.WriteLine(seller.Address.BuildingNum);
                    foreach (Product product in seller.Products)
                    {
                        sw.WriteLine(product.ProductName);
                        sw.WriteLine(product.SerialNumber);
                        sw.WriteLine(product.Price);
                        sw.WriteLine(product.Type);
                    }
                    sw.WriteLine("");
                }
                sw.Close();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Error saving file: ");
            }
            catch (Exception e)
            {
                throw new Exception("Error seving file: ");
            }

        }
        public void LoadFile()
        {
            try
            {
                List<Seller> loadSellers = new List<Seller>();
                Seller seller;
                List<Product> loadProducts = new List<Product>();
                string[] sellerInfo = new string[7];
                string[] productsInfo = new string[4];
                string line;
                Address address;
                Product product;
                StreamReader sr = new StreamReader(@"..\..\sellerFile.txt");
                while (!sr.EndOfStream)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        line = sr.ReadLine();
                        sellerInfo[i] = line;
                    }
                    address = new Address(sellerInfo[3], sellerInfo[4], sellerInfo[5], (int.Parse(sellerInfo[6])));
                    line = sr.ReadLine();
                    while (line != "")
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            productsInfo[i] = line;
                            line = sr.ReadLine();
                        }
                        product = new Product(productsInfo[0], int.Parse(productsInfo[1]), float.Parse(productsInfo[2]), (category)Enum.Parse(typeof(category), productsInfo[3]));
                        loadProducts.Add(product);
                    }
                    seller = new Seller(sellerInfo[0], sellerInfo[1], (int.Parse(sellerInfo[2])), address, loadProducts);
                    loadSellers.Add(seller);
                }
                sellers = loadSellers;
                sr.Close();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Error loading file: ");
            }
            catch (Exception e)
            {
                throw new Exception("Error loading file: ");
            }
        }
    }
}
