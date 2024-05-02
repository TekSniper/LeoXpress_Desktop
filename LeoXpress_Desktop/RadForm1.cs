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

namespace LeoXpress_Desktop
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        Main main;
        public RadForm1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void RadForm1_Load(object sender, EventArgs e)
        {
            tbPwd.UseSystemPasswordChar = true;
        }

        private void radCheckBox1_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {

        }

        private void radCheckBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if(radCheckBox1.Checked) 
                tbPwd.UseSystemPasswordChar = false;
            else
                tbPwd.UseSystemPasswordChar = true;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            var user = new Utilisateur();
            user.Login = tbLogin.Text.Trim();
            user.Mot_De_Passe = tbPwd.Text.Trim();
            var isAuthenticated = user.Authentification();
            if (isAuthenticated)
            {
                var isActive = user.VerificationStatus();
                if (!isActive)
                    MessageBox.Show("Cet utilisateur n'est pas actif. Vueillez consulter l'admin", "Utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    MessageBox.Show("Vous êtes connecté !", "Utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    main = new Main();
                    main.LoginUser = tbLogin.Text.Trim();
                    this.Hide();
                    main.Show();
                }
            }
            else
            {
                MessageBox.Show("Erreur login et/ou mot de passe...", "Utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
