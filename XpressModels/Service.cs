using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpressModels
{
    public class Service
    {
        public int ID { get; set; }
        public string Designation {  get; set; }
        public string Description {  get; set; }
        public decimal Prix {  get; set; }
        public string Image {  get; set; }
        public string CodeCate {  get; set; }
        public string DesignationCat { get; set; }

        public bool AddService()
        {
            var isTrue = false;
            using(var cnx = new dbConnection().GetConnection())
            {
                cnx.Open();
                var cm = new MySqlCommand("AddService", cnx);
                cm.Parameters.Add(new MySqlParameter("design", Designation));
                cm.Parameters.Add(new MySqlParameter("descr", Description));
                cm.Parameters.Add(new MySqlParameter("prix_s", Prix));
                cm.Parameters.Add(new MySqlParameter("codecate", CodeCate));
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                var i = cm.ExecuteNonQuery();
                if (i != 0)
                    isTrue = true;
                else
                    isTrue = false;
            }

            return isTrue;
        }
    }
}
