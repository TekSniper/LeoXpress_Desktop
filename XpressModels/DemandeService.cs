using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpressModels
{
    public class DemandeService
    {
        public int Id {  get; set; }
        public int ClientId { get; set; }
        public DateTime DateDemande { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int UserId { get; set; }
        public string UserLogin {  get; set; }

        public bool AddDemande()
        {
            var isTrue = false;
            using(var cnx = new dbConnection().GetConnection())
            {
                cnx.Open();
                var cm = new MySqlCommand("AddDemande", cnx);
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.Add(new MySqlParameter("idclient", ClientId));
                cm.Parameters.Add(new MySqlParameter("datedem", DateDemande));
                cm.Parameters.Add(new MySqlParameter("descri", Description));
                cm.Parameters.Add(new MySqlParameter("statut", Status));
                cm.Parameters.Add(new MySqlParameter("loginuser", UserLogin));

                var i = cm.ExecuteNonQuery();
                if(i != 0)
                    isTrue = true;
                else
                    isTrue = false;
            }

            return isTrue;
        }
        public int GetLastIdDemandeServiceByClientUser()
        {
            var id = 0;
            using(var cnx = new dbConnection().GetConnection())
            {
                cnx.Open();
                var cm = new MySqlCommand("GetLastIdDemandeServiceByClientUser", cnx);
                cm.Parameters.Add(new MySqlParameter("loginuser", UserLogin));
                cm.Parameters.Add(new MySqlParameter("idclient", ClientId));
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = cm.ExecuteReader();
                if(reader.Read())
                    id = reader.GetInt32(0);
            }

            return id;
        }
    }
}
