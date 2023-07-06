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
        public string CreditCardNumber { get; set; }
        public int PinCode { get; set; }

        public User(string firstName, string lastName, string creditCardNumber, int pinCode)
        {
            firstName = FirstName; 
            lastName = LastName;
            CreditCardNumber = creditCardNumber;
            PinCode = pinCode;
        }
    }
}
