using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTAR.MVVM.Model
{
    public enum Gender { Male, Female, Other}
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set;}
        public string Email { get; set; }

        public User(string firstname, string lastname, string username, string password, Gender gender, string email)
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
