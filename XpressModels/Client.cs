using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpressModels
{
    public class Client
    {
        public int Id { get; set; }
        public string Nom {  get; set; }
        public string Phone {  get; set; }
        public int UserId { get; set; }
        public string UserLogin { get; set; }

        public bool AddClient()
        {
            var isTrue = false;
            using(var cnx = new dbConnection().GetConnection())
            {
                cnx.Open();
                var cm = new MySqlCommand("AddClient", cnx);
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.Add(new MySqlParameter("v_nom",Nom));
                cm.Parameters.Add(new MySqlParameter("v_phone", Phone));
                cm.Parameters.Add(new MySqlParameter("loginuser", UserLogin));
                var i = cm.ExecuteNonQuery();
                if(i != 0)
                    isTrue = true;
                else
                    isTrue = false;
            }

            return isTrue;
        }
        public int GetIdClientByUser()
        {
            var id = 0;
            using(var cnx = new dbConnection().GetConnection())
            {
                cnx.Open();
                var cm = new MySqlCommand("GetIdClientByUser", cnx);
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.Add(new MySqlParameter("loginuser", UserLogin));
                var reader = cm.ExecuteReader();
                if(reader.Read())
                    id = reader.GetInt32(0);
            }

            return id;
        }
        public int GetLastIdClientByUser()
        {
            var id = 0;
            using (var cnx = new dbConnection().GetConnection())
            {
                cnx.Open();
                var cm = new MySqlCommand("GetLastIdClientByUser", cnx);
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.Add(new MySqlParameter("loginuser", UserLogin));
                var reader = cm.ExecuteReader();
                if (reader.Read())
                    id = reader.GetInt32(0);
            }

            return id;
        }
    }
}
