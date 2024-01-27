namespace eDostava.WinUI
{
    partial class frmPregledKorisnikaAdmin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPregledKorisnikaAdmin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbLogOut = new System.Windows.Forms.PictureBox();
            this.pbRestaurant = new System.Windows.Forms.PictureBox();
            this.pbUsers = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIzvhestaj = new System.Windows.Forms.Button();
            this.dgvKorisnici = new System.Windows.Forms.DataGridView();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uloga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.korisnikBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtKorisnickoIme = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRestaurant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKorisnici)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.korisnikBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel1.Controls.Add(this.pbLogOut);
            this.panel1.Controls.Add(this.pbRestaurant);
            this.panel1.Controls.Add(this.pbUsers);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(-2, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 522);
            this.panel1.TabIndex = 0;
            // 
            // pbLogOut
            // 
            this.pbLogOut.Image = ((System.Drawing.Image)(resources.GetObject("pbLogOut.Image")));
            this.pbLogOut.Location = new System.Drawing.Point(99, 342);
            this.pbLogOut.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbLogOut.Name = "pbLogOut";
            this.pbLogOut.Size = new System.Drawing.Size(50, 51);
            this.pbLogOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogOut.TabIndex = 6;
            this.pbLogOut.TabStop = false;
            this.pbLogOut.Click += new System.EventHandler(this.pbLogOut_Click);
            // 
            // pbRestaurant
            // 
            this.pbRestaurant.Image = ((System.Drawing.Image)(resources.GetObject("pbRestaurant.Image")));
            this.pbRestaurant.Location = new System.Drawing.Point(99, 227);
            this.pbRestaurant.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbRestaurant.Name = "pbRestaurant";
            this.pbRestaurant.Size = new System.Drawing.Size(50, 51);
            this.pbRestaurant.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRestaurant.TabIndex = 4;
            this.pbRestaurant.TabStop = false;
            this.pbRestaurant.Click += new System.EventHandler(this.pbRestaurant_Click_1);
            // 
            // pbUsers
            // 
            this.pbUsers.Image = ((System.Drawing.Image)(resources.GetObject("pbUsers.Image")));
            this.pbUsers.Location = new System.Drawing.Point(99, 113);
            this.pbUsers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbUsers.Name = "pbUsers";
            this.pbUsers.Size = new System.Drawing.Size(50, 51);
            this.pbUsers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUsers.TabIndex = 3;
            this.pbUsers.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(276, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(664, 518);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(294, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "PREGLED KORISNIKA";
            // 
            // btnIzvhestaj
            // 
            this.btnIzvhestaj.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnIzvhestaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzvhestaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnIzvhestaj.Location = new System.Drawing.Point(670, 474);
            this.btnIzvhestaj.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnIzvhestaj.Name = "btnIzvhestaj";
            this.btnIzvhestaj.Size = new System.Drawing.Size(250, 35);
            this.btnIzvhestaj.TabIndex = 3;
            this.btnIzvhestaj.Text = "GENERIŠI IZVJEŠTAJ";
            this.btnIzvhestaj.UseVisualStyleBackColor = false;
            // 
            // dgvKorisnici
            // 
            this.dgvKorisnici.AllowUserToAddRows = false;
            this.dgvKorisnici.AllowUserToDeleteRows = false;
            this.dgvKorisnici.BackgroundColor = System.Drawing.Color.White;
            this.dgvKorisnici.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvKorisnici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKorisnici.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ime,
            this.Prezime,
            this.Uloga,
            this.Status});
            this.dgvKorisnici.Location = new System.Drawing.Point(300, 107);
            this.dgvKorisnici.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvKorisnici.Name = "dgvKorisnici";
            this.dgvKorisnici.ReadOnly = true;
            this.dgvKorisnici.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKorisnici.Size = new System.Drawing.Size(620, 360);
            this.dgvKorisnici.TabIndex = 4;
            // 
            // Ime
            // 
            this.Ime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ime.DataPropertyName = "Ime";
            this.Ime.HeaderText = "Ime";
            this.Ime.Name = "Ime";
            this.Ime.ReadOnly = true;
            // 
            // Prezime
            // 
            this.Prezime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Prezime.DataPropertyName = "Prezime";
            this.Prezime.HeaderText = "Prezime";
            this.Prezime.Name = "Prezime";
            this.Prezime.ReadOnly = true;
            // 
            // Uloga
            // 
            this.Uloga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Uloga.DataPropertyName = "UlogaIme";
            this.Uloga.HeaderText = "Uloga";
            this.Uloga.Name = "Uloga";
            this.Uloga.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // korisnikBindingSource
            // 
            this.korisnikBindingSource.DataSource = typeof(eDostava.Model.Korisnik);
            // 
            // txtKorisnickoIme
            // 
            this.txtKorisnickoIme.Location = new System.Drawing.Point(300, 66);
            this.txtKorisnickoIme.Name = "txtKorisnickoIme";
            this.txtKorisnickoIme.Size = new System.Drawing.Size(208, 23);
            this.txtKorisnickoIme.TabIndex = 6;
            this.txtKorisnickoIme.TextChanged += new System.EventHandler(this.txtKorisnickoIme_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(300, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Korisnicko ime";
            // 
            // frmPregledKorisnikaAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKorisnickoIme);
            this.Controls.Add(this.dgvKorisnici);
            this.Controls.Add(this.btnIzvhestaj);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmPregledKorisnikaAdmin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmPregledKorisnikaAdmin_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRestaurant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKorisnici)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.korisnikBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIzvhestaj;
        private System.Windows.Forms.PictureBox pbUsers;
        private System.Windows.Forms.PictureBox pbLogOut;
        private System.Windows.Forms.PictureBox pbRestaurant;
        private System.Windows.Forms.DataGridView dgvKorisnici;
        private BindingSource korisnikBindingSource;
        private TextBox txtKorisnickoIme;
        private Label label2;
        private DataGridViewTextBoxColumn Ime;
        private DataGridViewTextBoxColumn Prezime;
        private DataGridViewTextBoxColumn Uloga;
        private DataGridViewCheckBoxColumn Status;
    }
}