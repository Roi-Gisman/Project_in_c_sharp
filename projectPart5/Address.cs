using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectPart5
{
    internal class Address
    {
        private string street;
        private string city;
        private string state;
        private int buildingNum;
        public Address(string state, string city, string street, int buildingNum)
        {
            Street = street;
            City = city;
            State = state;
            BuildingNum = buildingNum;
        }
        public Address()
        {
            this.street = "";
            this.city = "";
            this.state = "";
            this.buildingNum = 0;
        }
        public Address(Address address)
        {
            this.street = address.street;
            this.city = address.city;
            this.state = address.state;
            this.buildingNum = address.buildingNum;
        }
        public string Street
        {
            get { return street; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Street cannot be empty.");
                }
                street = value;
            }
        }
        public string City
        {
            get { return city; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("City cannot be empty.");
                }
                city = value;
            }
        }
        public string State
        {
            get { return state; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("state cannot be empty.");
                }
                state = value;
            }
        }
        public int BuildingNum
        {
            get { return buildingNum; }
            set
            {
                if (value < 1)
                {
                    throw new OverflowException("The number of building should be positive");
                }
                buildingNum = value;
            }
        }
        public override string ToString()
        {
            string str = "state: " + this.state + "\ncity: " + this.city + "\nstreet: " + this.street + "\nbuilding number: " + this.buildingNum + "\n";
            return str;
        }
        public override bool Equals(object obj)
        {
            Address temp = obj as Address;
            if (temp == null)
                return false;
            return street.Equals(temp.street) && city.Equals(temp.city) && state.Equals(temp.state) && (buildingNum == temp.buildingNum);
        }
    }
}
