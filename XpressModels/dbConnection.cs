using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace XpressModels
{
    public class dbConnection
    {
        private MySqlConnection _connectionString { get; set; }
        public MySqlConnection GetConnection()
        {
            this._connectionString = new MySqlConnection(
                ConfigurationManager.ConnectionStrings["Xpr€$$"].ConnectionString
                );

            return _connectionString;
        }
    }
}
