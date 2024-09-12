using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectPart5
{
    internal class Special_Packaging_Prod : Product
    {
        private float packingPrice;


        public Special_Packaging_Prod(Special_Packaging_Prod other) : base(other)
        {
            packingPrice = other.packingPrice;
        }


        public Special_Packaging_Prod(string productName, float price, category type, float packingPrice) : base(productName, price + packingPrice, type)
        {
            PackingPrice = packingPrice;
        }
        public float PackingPrice
        {
            get { return packingPrice; }
            set { packingPrice = value; }
        }

        public override string ToString()
        {
            return base.ToString() + "pakaging price : " + this.packingPrice;
        }

        public override bool Equals(object obj)
        {
            Special_Packaging_Prod temp = obj as Special_Packaging_Prod;
            if (temp == null)
                return false;
            return base.Equals(obj) && (packingPrice == temp.packingPrice);

        }
    }
}
