using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimootiveServer.Classes
{
    class UltimootiveServerRuntime
    {
        #region Fields
        private UltimootiveServerDatabaseConnection databaseConnection = null;
        #endregion

        #region Constructors
        public UltimootiveServerRuntime()
        {
            databaseConnection = new UltimootiveServerDatabaseConnection();
        }
        #endregion

        #region Methods
        public void testDatabase()
        {
            databaseConnection.testConnection();
        }
        public void createDefaultTables()
        {
            databaseConnection.createDefaultTables();
        }
        public void dropDefaultTables()
        {
            databaseConnection.dropDefaultTables();
        }
        #endregion
    }
}
