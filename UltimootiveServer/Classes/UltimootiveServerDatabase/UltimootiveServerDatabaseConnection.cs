using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimootiveServer.Classes
{
    class UltimootiveServerDatabaseConnection
    {
        #region Fields
        private MySql.Data.MySqlClient.MySqlConnection connection = null;
        private string connectionString;
        #endregion

        #region Constructors
        public UltimootiveServerDatabaseConnection()
        {
            connectionString = "server=127.0.0.1;port=3306;uid=db_user;pwd=password;database=ultimootivedb;";
            connection = new MySql.Data.MySqlClient.MySqlConnection();
            connection.ConnectionString = connectionString;
        }
        /*public UltimootiveServerDatabaseConnection(string dbURL, dbUser, dbPassword)
        {

        }*/
        #endregion

        #region methods
        public void testConnection()
        {
            try
            {
                connection.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void createDefaultTables()
        {
            try
            {
                connection.Open();
                string sqlCMD = @"CREATE TABLE IF NOT EXISTS User (uid int(5) NOT NULL AUTO_INCREMENT, username varchar(10) DEFAULT '', password varchar(10) DEFAULT '', PRIMARY KEY(uid))";
                MySqlCommand cmd = new MySqlCommand(sqlCMD, connection);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                String outp = err.ToString();
                Console.WriteLine("Error: " + err.ToString());
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public void dropDefaultTables()
        {
            try
            {
                connection.Open();
                String sqlCMD = @"drop table if exists User, CharSheetTemplates, CharSheetContent;";
                MySqlCommand cmd = new MySqlCommand(sqlCMD, connection);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                String outp = err.ToString();
                Console.WriteLine("Error: " + err.ToString());
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
    }
    #endregion
}






