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
        public double Income { get; set; }
        public double Balance { get; set; }
        public double WishListPrice { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public UserVM(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Income = user.Income;
            Balance = user.Balance;
            WishListPrice = user.WishListPrice;
            Username = user.Username;
            Password = user.Password;
        }
    }
}
