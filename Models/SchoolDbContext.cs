using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;

using MySql.Data.MySqlClient;

namespace School.Models
{
    public class SchoolDbContext
    {       
        //Only the schoolDbContext class can use them.
        private static string User { get { return "root"; } }
        private static string Password { get { return "root"; } }
        private static string Database { get { return "school"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3307"; } }

        //ConnectionString is a series of credentials used to connect to the database.
        protected static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password;
            }
        }        
        /// <summary>
        /// Returns a connection to the school database.
        /// </summary>
        /// <example>
        /// private schoolDbContext school = new schoolDbContext();
        /// MySqlConnection Conn = school.AccessDatabase();
        /// </example>
        /// <returns>A MySqlConnection Object</returns>
        public MySqlConnection AccessDatabase()
        {
            //We are instantiating the MySqlConnection Class to create an object
            //the object is a specific connection to our school database on port 3307 of localhost
            return new MySqlConnection(ConnectionString);
        }
    }
}