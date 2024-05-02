using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpressModels
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Login { get; set; }
        public string Mot_De_Passe { get; set; }
        public string Ip_Host { get; set; }
        public string Host_Name { get; set; }
        public DateTime DateConnexion { get; set; }
        public DateTime HeureConnexion { get; set; }
        public int statut { get; set; }

        public bool VerificationStatus()
        {
            var isTrue = false;
            using(var cnx = new dbConnection().GetConnection())
            {
                cnx.Open();
                var cm = new MySqlCommand("select * from utilisateur where login=@login", cnx);
                cm.Parameters.AddWithValue("@login", this.Login);
                var reader= cm.ExecuteReader();
                var s = 0;
                if (reader.Read())
                    s = reader.GetInt32(8);
                if (s != 0) isTrue = true;
                else isTrue = false;
            }

            return isTrue;
        }
        public bool Authentification()
        {
            var isTrue = false;
            using(var cnx = new dbConnection().GetConnection())
            {
                cnx.Open();
                var cm = new MySqlCommand("Authentification", cnx);
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.Add(new MySqlParameter("p_login", this.Login));
                cm.Parameters.Add(new MySqlParameter("pwd", this.Mot_De_Passe));
                var reader= cm.ExecuteReader(); 
                if(reader.Read())
                    isTrue = true;
                else 
                    isTrue = false;
            }


            return isTrue;
        }
        public int GetIdUser()
        {
            var ID = 0;
            using(var cnx= new dbConnection().GetConnection())
            {
                cnx.Open();
                var cm = new MySqlCommand("GetIdUser", cnx);
                cm.Parameters.Add(new MySqlParameter("p_login", Login));
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                var reader= cm.ExecuteReader();
                if(reader.Read())
                    ID = reader.GetInt32(0);
            }

            return ID;
        }
    }
}
