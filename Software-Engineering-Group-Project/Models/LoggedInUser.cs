using SftEngGP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SftEngGP.Database.Models;

namespace SftEngGP.Models
{
    sealed internal class LoggedInUser
    {

        private static LoggedInUser? _instance = null;
        public string Email { get; set; }
        public int Role { get; set; }

        private LoggedInUser()
        {
        }

        public static LoggedInUser GetInstance()
        {
            if (_instance == null)
            {
                _instance = new LoggedInUser();
            }

            return _instance;
        }


        public string Login(string email, int roleID)
        {
            Email = email;
            Role = roleID;
            
            return "Logged in";
        }


        public string Logout()
        {
             _instance = null;
            return "Logged out";
        }




    }
}
