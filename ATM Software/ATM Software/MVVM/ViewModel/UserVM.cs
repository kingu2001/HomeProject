using ATM_Software.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Software.MVVM.ViewModel
{
    class UserVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CreditCardNumber { get; set; }
        public int PinCode { get; set; }

        public UserVM(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            CreditCardNumber = user.CreditCardNumber;
            PinCode = user.PinCode;
        }
    }
}
