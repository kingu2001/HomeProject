using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Software.MVVM.Model
{
    class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Income { get; set; }
        public double Balance { get; set; }
        public double WishListPrice { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string firstName, string lastName, double income, double balance, double wishListPrice, string username, string password)
        {
            firstName = FirstName; 
            lastName = LastName;
            income = Income;
            balance = Balance;
            wishListPrice = WishListPrice; 
            username = Username; 
            password = Password;
        }

        public override string ToString()
        {
            return $"{FirstName}:{LastName}:{Income}:{Balance}:{WishListPrice}:{Username}:{Password}";
        }
    }
}
