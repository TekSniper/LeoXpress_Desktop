using LeoXpress_Desktop.UserForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XpressModels;

namespace LeoXpress_Desktop.UserControls
{
    public partial class Service_UC : UserControl
    {
        public Service_UC()
        {
            InitializeComponent();
        }
        List<Service> services;
        public string ClientName { get; set; } = string.Empty;
        public string ClientPhone { get; set; } = string.Empty; 
        public string LoginUser { get; set; }
        private void Service_UC_Load(object sender, EventArgs e)
        {
            RefreshControl();
            lbClient.Text = lbClient.Text + " " + ClientName;
        }
        List<Service> GetServices()
        {
            using (var cnx = new dbConnection().GetConnection())
            {
                cnx.Open();
                var cm = new MySqlCommand("GetServices", cnx);
                cm.CommandType = CommandType.StoredProcedure;
                services = new List<Service>();
                var reader = cm.ExecuteReader();
                while (reader.Read())
                {
                    var service = new Service();
                    service.ID = reader.GetInt32(0);
                    service.Designation = reader.GetString(1);
                    service.Description = reader.GetString(2);
                    service.Prix = reader.GetDecimal(3);
                    service.DesignationCat = reader.GetString(4);
                    services.Add(service);
                }

                return services;
            }
        }
        public void RefreshControl()
        {
            var count = GetServices().Count;
            gridService.RowCount = count;
            var i = 0;
            foreach (var service in GetServices())
            {
                gridService.Rows[i].Cells[0].Value = service.ID;
                gridService.Rows[i].Cells[1].Value = service.Designation;
                gridService.Rows[i].Cells[2].Value = service.Description;
                gridService.Rows[i].Cells[3].Value = service.Prix;
                gridService.Rows[i].Cells[4].Value = service.DesignationCat;


                i += 1;
            }
            //gridService.DataSource = services;
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            NouveauService nouveauService = new NouveauService();
            nouveauService.ShowDialog();
        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            var demandeService = new UserForms.DemandeService();
            demandeService.LoginUser = this.LoginUser;
            demandeService.ShowDialog();
        }
    }
}
