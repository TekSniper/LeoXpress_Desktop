using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpressModels
{
    public class LigneDemande
    {
        public int Id {  get; set; }
        public int DemandeId {  get; set; }
        public int ServiceId {  get; set; }
        public decimal Prix {  get; set; }
        public int Quantite { get; set; }

        public bool AddLigndeDemande()
        {
            var isTrue = false;
            using(var cnx = new dbConnection().GetConnection())
            {
                cnx.Open();
                var cm = new MySqlCommand("AddLigndeDemande", cnx);
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.Add(new MySqlParameter("idservice", ServiceId));
                cm.Parameters.Add(new MySqlParameter("iddemande", DemandeId));
                cm.Parameters.Add(new MySqlParameter("prixdem", Prix));
                cm.Parameters.Add(new MySqlParameter("qte", Quantite));

                var i = cm.ExecuteNonQuery();
                if (i != 0) isTrue = true;
                else isTrue = false;
            }

            return isTrue;
        }
    }
}
