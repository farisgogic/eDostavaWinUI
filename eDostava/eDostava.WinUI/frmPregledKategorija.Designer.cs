namespace eDostava.WinUI
{
    partial class frmPregledKategorija
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPregledKategorija));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbOrders = new System.Windows.Forms.PictureBox();
            this.pbCategory = new System.Windows.Forms.PictureBox();
            this.pbLogOut = new System.Windows.Forms.PictureBox();
            this.pbAccount = new System.Windows.Forms.PictureBox();
            this.pbMeal = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDodajKategoriju = new System.Windows.Forms.Button();
            this.btnGenerisiIzvjestaj = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvKategorije = new System.Windows.Forms.DataGridView();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMeal)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKategorije)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel1.Controls.Add(this.pbOrders);
            this.panel1.Controls.Add(this.pbCategory);
            this.panel1.Controls.Add(this.pbLogOut);
            this.panel1.Controls.Add(this.pbAccount);
            this.panel1.Controls.Add(this.pbMeal);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 527);
            this.panel1.TabIndex = 1;
            // 
            // pbOrders
            // 
            this.pbOrders.Image = ((System.Drawing.Image)(resources.GetObject("pbOrders.Image")));
            this.pbOrders.Location = new System.Drawing.Point(104, 115);
            this.pbOrders.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbOrders.Name = "pbOrders";
            this.pbOrders.Size = new System.Drawing.Size(57, 62);
            this.pbOrders.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOrders.TabIndex = 7;
            this.pbOrders.TabStop = false;
            this.pbOrders.Click += new System.EventHandler(this.pbOrders_Click);
            // 
            // pbCategory
            // 
            this.pbCategory.Image = ((System.Drawing.Image)(resources.GetObject("pbCategory.Image")));
            this.pbCategory.Location = new System.Drawing.Point(104, 321);
            this.pbCategory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbCategory.Name = "pbCategory";
            this.pbCategory.Size = new System.Drawing.Size(57, 62);
            this.pbCategory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCategory.TabIndex = 5;
            this.pbCategory.TabStop = false;
            this.pbCategory.Click += new System.EventHandler(this.pbCategory_Click);
            // 
            // pbLogOut
            // 
            this.pbLogOut.Image = ((System.Drawing.Image)(resources.GetObject("pbLogOut.Image")));
            this.pbLogOut.Location = new System.Drawing.Point(104, 428);
            this.pbLogOut.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbLogOut.Name = "pbLogOut";
            this.pbLogOut.Size = new System.Drawing.Size(57, 62);
            this.pbLogOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogOut.TabIndex = 4;
            this.pbLogOut.TabStop = false;
            this.pbLogOut.Click += new System.EventHandler(this.pbLogOut_Click);
            // 
            // pbAccount
            // 
            this.pbAccount.Image = ((System.Drawing.Image)(resources.GetObject("pbAccount.Image")));
            this.pbAccount.Location = new System.Drawing.Point(104, 20);
            this.pbAccount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbAccount.Name = "pbAccount";
            this.pbAccount.Size = new System.Drawing.Size(57, 62);
            this.pbAccount.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAccount.TabIndex = 3;
            this.pbAccount.TabStop = false;
            this.pbAccount.Click += new System.EventHandler(this.pbAccount_Click);
            // 
            // pbMeal
            // 
            this.pbMeal.Image = ((System.Drawing.Image)(resources.GetObject("pbMeal.Image")));
            this.pbMeal.Location = new System.Drawing.Point(104, 210);
            this.pbMeal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbMeal.Name = "pbMeal";
            this.pbMeal.Size = new System.Drawing.Size(57, 62);
            this.pbMeal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMeal.TabIndex = 2;
            this.pbMeal.TabStop = false;
            this.pbMeal.Click += new System.EventHandler(this.pbMeal_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel2.Location = new System.Drawing.Point(302, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(631, 522);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.btnDodajKategoriju);
            this.panel3.Controls.Add(this.btnGenerisiIzvjestaj);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtNaziv);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.dgvKategorije);
            this.panel3.Location = new System.Drawing.Point(302, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(608, 527);
            this.panel3.TabIndex = 2;
            // 
            // btnDodajKategoriju
            // 
            this.btnDodajKategoriju.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnDodajKategoriju.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDodajKategoriju.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDodajKategoriju.ForeColor = System.Drawing.Color.Black;
            this.btnDodajKategoriju.Location = new System.Drawing.Point(24, 480);
            this.btnDodajKategoriju.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDodajKategoriju.Name = "btnDodajKategoriju";
            this.btnDodajKategoriju.Size = new System.Drawing.Size(181, 35);
            this.btnDodajKategoriju.TabIndex = 13;
            this.btnDodajKategoriju.Text = "DODAJ KATEGORIJU";
            this.btnDodajKategoriju.UseVisualStyleBackColor = false;
            this.btnDodajKategoriju.Click += new System.EventHandler(this.btnDodajKategoriju_Click);
            // 
            // btnGenerisiIzvjestaj
            // 
            this.btnGenerisiIzvjestaj.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnGenerisiIzvjestaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerisiIzvjestaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGenerisiIzvjestaj.ForeColor = System.Drawing.Color.Black;
            this.btnGenerisiIzvjestaj.Location = new System.Drawing.Point(358, 480);
            this.btnGenerisiIzvjestaj.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGenerisiIzvjestaj.Name = "btnGenerisiIzvjestaj";
            this.btnGenerisiIzvjestaj.Size = new System.Drawing.Size(236, 35);
            this.btnGenerisiIzvjestaj.TabIndex = 12;
            this.btnGenerisiIzvjestaj.Text = "GENERIŠI IZVJEŠTAJ";
            this.btnGenerisiIzvjestaj.UseVisualStyleBackColor = false;
            this.btnGenerisiIzvjestaj.Click += new System.EventHandler(this.btnGenerisiIzvjestaj_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(24, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Naziv";
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(24, 76);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(202, 23);
            this.txtNaziv.TabIndex = 10;
            this.txtNaziv.TextChanged += new System.EventHandler(this.txtNaziv_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label2.Location = new System.Drawing.Point(24, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "PREGLED KATEGORIJA";
            // 
            // dgvKategorije
            // 
            this.dgvKategorije.AllowUserToAddRows = false;
            this.dgvKategorije.AllowUserToDeleteRows = false;
            this.dgvKategorije.BackgroundColor = System.Drawing.Color.White;
            this.dgvKategorije.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKategorije.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Naziv});
            this.dgvKategorije.Location = new System.Drawing.Point(24, 105);
            this.dgvKategorije.Name = "dgvKategorije";
            this.dgvKategorije.ReadOnly = true;
            this.dgvKategorije.RowTemplate.Height = 25;
            this.dgvKategorije.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKategorije.Size = new System.Drawing.Size(572, 359);
            this.dgvKategorije.TabIndex = 2;
            this.dgvKategorije.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKategorije_CellDoubleClick);
            // 
            // Naziv
            // 
            this.Naziv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            // 
            // frmPregledKategorija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 527);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "frmPregledKategorija";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPregledKategorija";
            this.Load += new System.EventHandler(this.frmPregledKategorija_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMeal)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKategorije)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private PictureBox pbCategory;
        private PictureBox pbLogOut;
        private PictureBox pbAccount;
        private PictureBox pbMeal;
        private Panel panel2;
        private Panel panel3;
        private DataGridView dgvKategorije;
        private Label label2;
        private Label label3;
        private TextBox txtNaziv;
        private Button btnDodajKategoriju;
        private Button btnGenerisiIzvjestaj;
        private DataGridViewTextBoxColumn Naziv;
        private PictureBox pbOrders;
    }
}