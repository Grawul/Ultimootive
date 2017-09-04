using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimootiveServer.Classes.UltimootiveServerDatabase
{
    class UserModel
    {
        #region Fields
        private string username;
        private string password;
        #endregion

        #region Constructors
        #endregion

        #region Properties
        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }
        #endregion

        #region methods
        #endregion
    }
}
