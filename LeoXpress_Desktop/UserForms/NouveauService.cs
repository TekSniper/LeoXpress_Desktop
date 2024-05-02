using LeoXpress_Desktop.UserControls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using XpressModels;

namespace LeoXpress_Desktop.UserForms
{
    public partial class NouveauService : Telerik.WinControls.UI.RadForm
    {
        public NouveauService()
        {
            InitializeComponent();
        }
        List<CategorieService> categories;
        Service service = new Service();
        private List<CategorieService> GetCategorieServices()
        {
            using(var cnx = new dbConnection().GetConnection())
            {
                cnx.Open();
                var cm = new MySqlCommand("select * from categorie_service", cnx);
                categories = new List<CategorieService>();
                var reader = cm.ExecuteReader();
                while (reader.Read())
                {
                    var categorie = new CategorieService();
                    categorie.Code = reader.GetString(0);
                    categorie.Designation = reader.GetString(1);

                    categories.Add(categorie);
                }

                return categories;
            }
        }

        private void NouveauService_Load(object sender, EventArgs e)
        {
            cbCat.DisplayMember = "Designation";
            cbCat.ValueMember = "Code";
            cbCat.DataSource = GetCategorieServices();
        }
        void RefreshForm()
        {
            tbDesc.Clear();
            tbDesignation.Clear();
            tbPrix.Clear();
            tbDesignation.Focus();
        }
        private void tbSave_Click(object sender, EventArgs e)
        {
            if (tbDesignation.Text == "" || tbDesc.Text == "" || tbPrix.Text == "")
                MessageBox.Show("Remplissez les vides s'il vous plait.", "Vides", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                var tp = 0;
                var isInt = int.TryParse(tbPrix.Text, out tp);
                if (!isInt)
                    MessageBox.Show("Le prix est une valeur numérique", "Prix", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    var isAdded = false;
                    service.Designation = tbDesignation.Text.Trim();
                    service.Description = tbDesc.Text.Trim();
                    service.Prix = int.Parse(tbPrix.Text);
                    service.CodeCate = cbCat.SelectedValue.ToString();
                    isAdded = service.AddService();

                    if(isAdded)
                    {
                        MessageBox.Show("Service ajouté avec succès.", "Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        new Service_UC().RefreshControl();
                    }
                    else
                    {
                        MessageBox.Show("Echec ajout du service.", "Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        new Service_UC().RefreshControl();
                    }
                }
            }
        }
    }
}
