using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Final
{
    internal class Users
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Users(string fullName, string email, string password)
        {
            FullName = fullName;
            Email = email;
            Password = password;
        }
    }
}
