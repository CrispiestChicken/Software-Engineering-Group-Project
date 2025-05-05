using SftEngGP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SftEngGP.Database.Models;

namespace SftEngGP.Models
{
    /// <summary>
    /// Singleton class to store the logged in users information.
    /// </summary>
    sealed internal class LoggedInUser
    {

        /// <summary>
        /// The instance of the logged in user.
        /// </summary>
        private static LoggedInUser? _instance = null;

        /// <summary>
        /// The email of the logged in user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The role of the logged in user.
        /// </summary>
        public int Role { get; set; }

        /// <summary>
        /// Private constructor to prevent multiple instances of the logged in user.
        /// </summary>
        private LoggedInUser()
        {
        }

        /// <summary>
        /// Gets the instance of the logged in user or creates one if it doesn't exist.
        /// </summary>
        /// <returns></returns>
        public static LoggedInUser GetInstance()
        {
            if (_instance == null)
            {
                _instance = new LoggedInUser();
            }

            return _instance;
        }


        /// <summary>
        /// Logs in the user by setting the email and role.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public string Login(string email, int roleID)
        {
            Email = email;
            Role = roleID;
            
            return "Logged in";
        }


        /// <summary>
        /// Logs out the user by setting the instance to null.
        /// </summary>
        /// <returns></returns>
        public string Logout()
        {
             _instance = null;
            return "Logged out";
        }




    }
}
