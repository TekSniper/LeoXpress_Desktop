using LeoXpress_Desktop.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeoXpress_Desktop
{
    public partial class Main : Telerik.WinControls.UI.RadForm
    {
        public string LoginUser {  get; set; }
        public Main()
        {
            InitializeComponent();
            radLabel3.Text = LoginUser;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            radLabel2.Text = DateTime.Now.Date.ToString();
            radLabel3.Text = LoginUser;
            //mainPanel.Controls.Add(new Dashboard_UC());
            //mainPanel.Dock = DockStyle.Fill;
            //mainPanel.BringToFront();
            AddUserControlOnPanel(new Dashboard_UC());
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void AddUserControlOnPanel(UserControl control)
        {
            if(mainPanel.Controls.Count > 0)
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(control);
                mainPanel.Dock = DockStyle.Fill;
                mainPanel.BringToFront();
            }
            else
            {
                mainPanel.Controls.Add(control);
                mainPanel.Dock = DockStyle.Fill;
                mainPanel.BringToFront();
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            var service_uc = new Service_UC();
            service_uc.LoginUser = radLabel3.Text;
            AddUserControlOnPanel(service_uc);
        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            if(mainPanel.Controls.Count > 0)
            {
                mainPanel.Controls.Clear();
                AddUserControlOnPanel(new Dashboard_UC());
            }
        }
    }
}
