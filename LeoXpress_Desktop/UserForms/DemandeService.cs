using LeoXpress_Desktop.UserControls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using XpressModels;

namespace LeoXpress_Desktop.UserForms
{
    public partial class DemandeService : Telerik.WinControls.UI.RadForm
    {
        Dictionary<int, string> services;
        //Service service = new Service();
        Service_UC service_uc = new Service_UC();
        public string LoginUser { get; set; }
        public DemandeService()
        {
            InitializeComponent();
        }
        private Dictionary<int, string> GetServices()
        {
            using (var cnx = new dbConnection().GetConnection())
            {
                cnx.Open();
                var cm = new MySqlCommand("select * from service", cnx);
                services = new Dictionary<int, string>();
                var reader = cm.ExecuteReader();
                while (reader.Read())
                {
                    services.Add(reader.GetInt32(0), reader.GetString(1));
                }

                return services;
            }
        }
        void RefreshDemande()
        {
            listService.DataSource = GetServices().ToArray();
            listService.DisplayMember = "Value";
            listService.ValueMember = "Key";
            if(service_uc.ClientName == string.Empty || service_uc.ClientPhone == string.Empty) { }
            else 
            {
                tbClientName.Text = service_uc.ClientName;
                tbClientName.Enabled = false;
                tbPhoneClient.Text = service_uc.ClientPhone;
                tbPhoneClient.Enabled = false;
            }

            radDateTimePicker1.Value = DateTime.Now.Date;
        }
        private void DemandeService_Load(object sender, EventArgs e)
        {
            RefreshDemande();
        }

        private void radGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void radDropDownList1_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void cbService_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            
        }

        private void listService_ItemMouseClick(object sender, Telerik.WinControls.UI.ListViewItemEventArgs e)
        {
            using (var cnx = new dbConnection().GetConnection())
            {
                cnx.Open();
                var cm = new MySqlCommand("select * from service where id=@id", cnx);
                cm.Parameters.AddWithValue("@id", int.Parse(listService.SelectedItem.Value.ToString()));
                var reader = cm.ExecuteReader();
                if (reader.Read())
                    tbPrix.Text = reader.GetDecimal(3).ToString();
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            //service_uc.ClientName = tbClientName.Text.Trim();
            //service_uc.ClientPhone = tbPhoneClient.Text.Trim();
            var cart_lignes = radGridView1.Rows.Count;
            if(cart_lignes == 0)
            {
                radGridView1.RowCount = 1;
                radGridView1.Rows[0].Cells[0].Value = listService.SelectedItem.Value.ToString();
                radGridView1.Rows[0].Cells[1].Value = listService.SelectedItem.Text;
                var dec = 0.00M;
                var i = 0;
                var isDecimal1 = decimal.TryParse(tbPrix.Text, out dec);
                var isInteger = int.TryParse(tbQte.Text, out i);
                if(isDecimal1 && isInteger)
                {
                    radGridView1.Rows[0].Cells[2].Value = tbPrix.Text.Trim();
                    radGridView1.Rows[0].Cells[3].Value = tbQte.Text.Trim();
                }
                else
                {
                    MessageBox.Show("Le prix et la quantité sont des valeurs numériques", "Prix et Quantité", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if(cart_lignes > 0)
            {
                radGridView1.RowCount = cart_lignes + 1;
                var c = radGridView1.Rows.Count - 1;
                radGridView1.Rows[c].Cells[0].Value = listService.SelectedItem.Value.ToString();
                radGridView1.Rows[c].Cells[1].Value = listService.SelectedItem.Text;
                var dec = 0.00M;
                var i = 0;
                var isDecimal1 = decimal.TryParse(tbPrix.Text, out dec);
                var isInteger = int.TryParse(tbQte.Text, out i);
                if (isDecimal1 && isInteger)
                {
                    radGridView1.Rows[c].Cells[2].Value = tbPrix.Text.Trim();
                    radGridView1.Rows[c].Cells[3].Value = tbQte.Text.Trim();
                }
                else
                {
                    MessageBox.Show("Le prix et la quantité sont des valeurs numériques", "Prix et Quantité", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            var client = new Client();
            if (tbClientName.Text == "")
            {
                client.Nom = "Client";
            }
            if (tbClientName.Text.Length != 0)
            {
                client.Nom = tbClientName.Text;
            }
            if (tbPhoneClient.Text.Length == 0)
                client.Phone = "0";
            if (tbPhoneClient.Text.Length != 0)
                client.Phone = tbPhoneClient.Text;
            client.UserLogin = this.LoginUser;
            var addClient = client.AddClient();
            if (addClient)
            {
                var lastClientIdByUser = client.GetLastIdClientByUser();
                var c = radGridView1.Rows.Count;
                if (c == 0)
                    MessageBox.Show("Le panier ne contient aucun detail sur la demande du client !\nAjouter une ou plusieurs demande dans le panier avant de valider.", "Panier", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    var demande = new XpressModels.DemandeService();
                    demande.ClientId = lastClientIdByUser;
                    demande.DateDemande = radDateTimePicker1.Value;
                    if(tbDescription.Text.Length != 0)
                        demande.Description = tbDescription.Text;
                    if (tbDescription.Text.Length == 0)
                        demande.Description = "";
                    demande.Status = 1;
                    demande.UserLogin = this.LoginUser;
                    var addDemande = demande.AddDemande();
                    if (addDemande)
                    {
                        var lastDemandeByUser = demande.GetLastIdDemandeServiceByClientUser();
                        foreach (GridViewRowInfo row in radGridView1.Rows)
                        {
                            var ligneCmd = new LigneDemande();
                        }
                    }
                    else
                        MessageBox.Show("Erreur création d'une demande dans le système.", "Demande", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Erreur création du client !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
        }
    }
}
