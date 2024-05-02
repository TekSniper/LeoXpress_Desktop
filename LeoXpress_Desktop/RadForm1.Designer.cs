namespace LeoXpress_Desktop
{
    partial class RadForm1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RadForm1));
            this.office2019LightTheme1 = new Telerik.WinControls.Themes.Office2019LightTheme();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.tbLogin = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.tbPwd = new Telerik.WinControls.UI.RadTextBox();
            this.radCheckBox1 = new Telerik.WinControls.UI.RadCheckBox();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(113, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 129);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(12, 177);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(37, 19);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Login";
            this.radLabel1.ThemeName = "Office2019Light";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(12, 201);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(329, 22);
            this.tbLogin.TabIndex = 2;
            this.tbLogin.ThemeName = "Office2019Light";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(12, 247);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(80, 19);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "Mot de passe";
            this.radLabel2.ThemeName = "Office2019Light";
            // 
            // tbPwd
            // 
            this.tbPwd.Location = new System.Drawing.Point(12, 271);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.Size = new System.Drawing.Size(329, 22);
            this.tbPwd.TabIndex = 3;
            this.tbPwd.ThemeName = "Office2019Light";
            // 
            // radCheckBox1
            // 
            this.radCheckBox1.Location = new System.Drawing.Point(12, 310);
            this.radCheckBox1.Name = "radCheckBox1";
            this.radCheckBox1.Size = new System.Drawing.Size(153, 17);
            this.radCheckBox1.TabIndex = 4;
            this.radCheckBox1.Text = "Afficher le mot de passe";
            this.radCheckBox1.ThemeName = "Office2019Light";
            this.radCheckBox1.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radCheckBox1_ToggleStateChanged);
            this.radCheckBox1.CheckStateChanged += new System.EventHandler(this.radCheckBox1_CheckStateChanged);
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(113, 372);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(129, 34);
            this.radButton1.TabIndex = 5;
            this.radButton1.Text = "Se connecter";
            this.radButton1.ThemeName = "Office2019Light";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // RadForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 447);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.radCheckBox1);
            this.Controls.Add(this.tbPwd);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "RadForm1";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ThemeName = "Office2019Light";
            this.Load += new System.EventHandler(this.RadForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2019LightTheme office2019LightTheme1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox tbLogin;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox tbPwd;
        private Telerik.WinControls.UI.RadCheckBox radCheckBox1;
        private Telerik.WinControls.UI.RadButton radButton1;
    }
}