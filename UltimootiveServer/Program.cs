using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimootiveServer.Classes;

namespace UltimootiveServer
{
    class Program
    {
        static void Main(string[] args)
        {
            UltimootiveServerRuntime run = new UltimootiveServerRuntime();

            // --- Test area
            // -- Create database stuff
            // -- GRANT ALL PRIVILEGES ON ultimootivedb.* TO 'db_user'@'%' IDENTIFIED BY PASSWORD 'password' WITH GRANT OPTION;
            //run.testDatabase();
            //run.createDefaultTables();
            //run.dropDefaultTables();
            // --
            // ---

            Console.ReadKey();
        }
    }
}
