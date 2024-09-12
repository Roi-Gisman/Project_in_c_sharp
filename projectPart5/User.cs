using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace projectPart5
{
    internal class User
    {
        protected string username;
        protected string password;
        protected Address address;

        public User(string username, string password, Address address)
        {
            Username = username;
            Password = password;
            Address = address;
        }
        public User()
        {
            this.username = "";
            this.password = "";
            this.address = new Address();
        }
        public User(User other)
        {
            this.username = other.username;
            this.password = other.password;
            this.address = other.address;
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
        public string Password
        {
            get { return password; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Password cannot be empty.");
                }
                password = value;
            }
        }
        public Address Address
        {
            get { return address; }
            set { address = value; }
        }
        public override string ToString()
        {
            string str = "Name :" + this.username + "\n" + address.ToString() + "\n";
            return str;
        }
        public override bool Equals(object obj)
        {
            User temp = obj as User;
            if (temp == null)
                return false;
            return username.Equals(temp.username) && password.Equals(temp.password) && address.Equals(temp.address);

        }
    }
}
