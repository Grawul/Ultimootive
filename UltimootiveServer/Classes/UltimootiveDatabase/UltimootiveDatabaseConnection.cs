using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimootiveServer.Classes
{
    class UltimootiveDatabaseConnection
    {
        #region Fields
        private MySql.Data.MySqlClient.MySqlConnection connection = null;
        private string connectionString;
        #endregion

        #region Constructors
        public UltimootiveDatabaseConnection()
        {
            connectionString = "server=127.0.0.1;port=3306;uid=db_user;pwd=password;database=ultimootivedb;";
            connection = new MySql.Data.MySqlClient.MySqlConnection();
            connection.ConnectionString = connectionString;
        }
        /*public UltimootiveDatabaseConnection(string dbURL, dbUser, dbPassword)
        {

        }*/
        #endregion

        #region Public_Methods
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
            List<string> sqlCMDList = new List<string>();
            sqlCMDList.Add(@"CREATE TABLE IF NOT EXISTS User (uid int(5) NOT NULL AUTO_INCREMENT, username varchar(10) DEFAULT '', password varchar(10) DEFAULT '', PRIMARY KEY(uid));");
            sqlCMDList.Add(@"CREATE TABLE IF NOT EXISTS AccessRight (uid int(5) NOT NULL AUTO_INCREMENT, accessRight varchar(10) DEFAULT '', PRIMARY KEY(uid));");
            sqlCMDList.Add(@"CREATE TABLE IF NOT EXISTS UserAccessRightMapping (uid int(5) NOT NULL AUTO_INCREMENT, userID int(5) DEFAULT NULL, accessRightID int(5) DEFAULT NULL, PRIMARY KEY(uid));");
            this.executeNonQueryCommandList(sqlCMDList);
        }

        public void createDefaultContent()
        {
            List<string> sqlCMDList = new List<string>();
            //Create root user
            sqlCMDList.Add(@"INSERT INTO User (username,password) VALUES ('root','root');");
            //Create basic rights
            sqlCMDList.Add(@"INSERT INTO AccessRight (accessRight) VALUES ('creator');");
            sqlCMDList.Add(@"INSERT INTO AccessRight (accessRight) VALUES ('player');");
            //Map root to these rights
            sqlCMDList.Add(@"INSERT INTO UserAccessRightMapping (userID,accessRightID) VALUES (1,1);");
            sqlCMDList.Add(@"INSERT INTO UserAccessRightMapping (userID,accessRightID) VALUES (1,2);");
            this.executeNonQueryCommandList(sqlCMDList);
        }

        public void dropDefaultTables()
        {
            String sqlCMD = @"drop table if exists User, AccessRight, UserAccessRightMapping;";
            this.executeNonQueryCommand(sqlCMD);
        }
        #endregion

        #region Private_Methods
        private void executeNonQueryCommand(string sqlCMD)
        {
            try
            {
                connection.Open();

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

        private void executeNonQueryCommandList(List<string> sqlCMDList)
        {
            try
            {
                connection.Open();

                foreach (string sqlCMD in sqlCMDList)
                {

                    MySqlCommand cmd = new MySqlCommand(sqlCMD, connection);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
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
        #endregion
    }

}






