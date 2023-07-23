using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTAR.MVVM.Model
{
    public class Administrator : User
    {
   
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }

        public Administrator(string firstname, string lastname, string username, string password, Gender gender, string email) : base(firstname, lastname, username, password, gender, email)
        {
            FirstName = firstname;
            LastName = lastname;
            Username = username;
            Password = password;
            Gender = gender;
            Email = email;
        }

        public override string ToString()
        {
            return $"{FirstName}{LastName}:{Username}:{Password}:{Gender}";
        }
    }
}
