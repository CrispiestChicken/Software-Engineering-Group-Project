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

        private static LoggedInUser? _instance;
        public string Email { get; set; }
        public int Role { get; set; }

        private LoggedInUser()
        {
        }

        public static LoggedInUser Instance
        {
            get
            {
                {
                    if (_instance == null)
                    {
                        _instance = new LoggedInUser();
                    }
                    return _instance;
                }
            }
        }


        public string Login(string email, int roleID)
        {
            _instance.Email = email;
            _instance.Role = roleID;

            return "Logged in";
        }


        public string Logout()
        {
            _instance = null;
            return "Logged out";
        }




    }
}
