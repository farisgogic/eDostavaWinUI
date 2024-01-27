namespace eDostava.WinUI
{
    partial class frmPregledJelaUR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPregledJelaUR));
            panel1 = new Panel();
            pbOrders = new PictureBox();
            pbCategory = new PictureBox();
            pbLogOut = new PictureBox();
            pbAccount = new PictureBox();
            pbMeal = new PictureBox();
            panel2 = new Panel();
            panel3 = new Panel();
            label2 = new Label();
            txtNaziv = new TextBox();
            dgvJelo = new DataGridView();
            Naziv = new DataGridViewTextBoxColumn();
            Sastav = new DataGridViewTextBoxColumn();
            Cijena = new DataGridViewTextBoxColumn();
            Kategorija = new DataGridViewTextBoxColumn();
            Ocjena = new DataGridViewTextBoxColumn();
            Slika = new DataGridViewImageColumn();
            btnDodajJelo = new Button();
            btnGenerisiIzvjestaj = new Button();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCategory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLogOut).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbAccount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMeal).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvJelo).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkTurquoise;
            panel1.Controls.Add(pbOrders);
            panel1.Controls.Add(pbCategory);
            panel1.Controls.Add(pbLogOut);
            panel1.Controls.Add(pbAccount);
            panel1.Controls.Add(pbMeal);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(-2, -1);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(303, 527);
            panel1.TabIndex = 0;
            // 
            // pbOrders
            // 
            pbOrders.Image = (Image)resources.GetObject("pbOrders.Image");
            pbOrders.Location = new Point(104, 125);
            pbOrders.Margin = new Padding(4, 3, 4, 3);
            pbOrders.Name = "pbOrders";
            pbOrders.Size = new Size(57, 62);
            pbOrders.SizeMode = PictureBoxSizeMode.StretchImage;
            pbOrders.TabIndex = 7;
            pbOrders.TabStop = false;
            pbOrders.Click += pbOrders_Click;
            // 
            // pbCategory
            // 
            pbCategory.Image = (Image)resources.GetObject("pbCategory.Image");
            pbCategory.Location = new Point(104, 330);
            pbCategory.Margin = new Padding(4, 3, 4, 3);
            pbCategory.Name = "pbCategory";
            pbCategory.Size = new Size(57, 62);
            pbCategory.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCategory.TabIndex = 5;
            pbCategory.TabStop = false;
            pbCategory.Click += pbCategory_Click;
            // 
            // pbLogOut
            // 
            pbLogOut.Image = (Image)resources.GetObject("pbLogOut.Image");
            pbLogOut.Location = new Point(104, 434);
            pbLogOut.Margin = new Padding(4, 3, 4, 3);
            pbLogOut.Name = "pbLogOut";
            pbLogOut.Size = new Size(57, 62);
            pbLogOut.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLogOut.TabIndex = 4;
            pbLogOut.TabStop = false;
            pbLogOut.Click += pbLogOut_Click;
            // 
            // pbAccount
            // 
            pbAccount.Image = (Image)resources.GetObject("pbAccount.Image");
            pbAccount.Location = new Point(104, 31);
            pbAccount.Margin = new Padding(4, 3, 4, 3);
            pbAccount.Name = "pbAccount";
            pbAccount.Size = new Size(57, 62);
            pbAccount.SizeMode = PictureBoxSizeMode.StretchImage;
            pbAccount.TabIndex = 3;
            pbAccount.TabStop = false;
            pbAccount.Click += pbAccount_Click;
            // 
            // pbMeal
            // 
            pbMeal.Image = (Image)resources.GetObject("pbMeal.Image");
            pbMeal.Location = new Point(104, 226);
            pbMeal.Margin = new Padding(4, 3, 4, 3);
            pbMeal.Name = "pbMeal";
            pbMeal.Size = new Size(57, 62);
            pbMeal.SizeMode = PictureBoxSizeMode.StretchImage;
            pbMeal.TabIndex = 2;
            pbMeal.TabStop = false;
            pbMeal.Click += pbMeal_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(192, 255, 255);
            panel2.Location = new Point(302, 0);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(631, 522);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(192, 255, 255);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(txtNaziv);
            panel3.Controls.Add(dgvJelo);
            panel3.Controls.Add(btnDodajJelo);
            panel3.Controls.Add(btnGenerisiIzvjestaj);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(300, -1);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(639, 531);
            panel3.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(16, 52);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 9;
            label2.Text = "Naziv";
            // 
            // txtNaziv
            // 
            txtNaziv.Location = new Point(16, 70);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(208, 23);
            txtNaziv.TabIndex = 8;
            txtNaziv.TextChanged += txtNaziv_TextChanged;
            // 
            // dgvJelo
            // 
            dgvJelo.AllowUserToAddRows = false;
            dgvJelo.AllowUserToDeleteRows = false;
            dgvJelo.BackgroundColor = Color.White;
            dgvJelo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvJelo.Columns.AddRange(new DataGridViewColumn[] { Naziv, Sastav, Cijena, Kategorija, Ocjena, Slika });
            dgvJelo.Location = new Point(16, 99);
            dgvJelo.Name = "dgvJelo";
            dgvJelo.ReadOnly = true;
            dgvJelo.RowTemplate.Height = 25;
            dgvJelo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvJelo.Size = new Size(604, 365);
            dgvJelo.TabIndex = 4;
            dgvJelo.CellDoubleClick += dgvJelo_CellDoubleClick;
            // 
            // Naziv
            // 
            Naziv.DataPropertyName = "Naziv";
            Naziv.HeaderText = "Naziv";
            Naziv.Name = "Naziv";
            Naziv.ReadOnly = true;
            // 
            // Sastav
            // 
            Sastav.DataPropertyName = "Opis";
            Sastav.HeaderText = "Sastav";
            Sastav.Name = "Sastav";
            Sastav.ReadOnly = true;
            // 
            // Cijena
            // 
            Cijena.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Cijena.DataPropertyName = "Cijena";
            Cijena.HeaderText = "Cijena";
            Cijena.Name = "Cijena";
            Cijena.ReadOnly = true;
            Cijena.Width = 65;
            // 
            // Kategorija
            // 
            Kategorija.DataPropertyName = "KategorijaNames";
            Kategorija.HeaderText = "Kategorija";
            Kategorija.Name = "Kategorija";
            Kategorija.ReadOnly = true;
            // 
            // Ocjena
            // 
            Ocjena.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Ocjena.DataPropertyName = "Ocjena";
            Ocjena.HeaderText = "Ocjena";
            Ocjena.Name = "Ocjena";
            Ocjena.ReadOnly = true;
            Ocjena.Width = 69;
            // 
            // Slika
            // 
            Slika.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Slika.DataPropertyName = "Slika";
            Slika.HeaderText = "Slika";
            Slika.ImageLayout = DataGridViewImageCellLayout.Stretch;
            Slika.Name = "Slika";
            Slika.ReadOnly = true;
            Slika.Resizable = DataGridViewTriState.True;
            Slika.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // btnDodajJelo
            // 
            btnDodajJelo.BackColor = Color.DarkTurquoise;
            btnDodajJelo.FlatStyle = FlatStyle.Flat;
            btnDodajJelo.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnDodajJelo.ForeColor = Color.Black;
            btnDodajJelo.Location = new Point(22, 478);
            btnDodajJelo.Margin = new Padding(4, 3, 4, 3);
            btnDodajJelo.Name = "btnDodajJelo";
            btnDodajJelo.Size = new Size(181, 35);
            btnDodajJelo.TabIndex = 3;
            btnDodajJelo.Text = "DODAJ JELO";
            btnDodajJelo.UseVisualStyleBackColor = false;
            btnDodajJelo.Click += btnDodajJelo_Click;
            // 
            // btnGenerisiIzvjestaj
            // 
            btnGenerisiIzvjestaj.BackColor = Color.DarkTurquoise;
            btnGenerisiIzvjestaj.FlatStyle = FlatStyle.Flat;
            btnGenerisiIzvjestaj.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnGenerisiIzvjestaj.ForeColor = Color.Black;
            btnGenerisiIzvjestaj.Location = new Point(384, 478);
            btnGenerisiIzvjestaj.Margin = new Padding(4, 3, 4, 3);
            btnGenerisiIzvjestaj.Name = "btnGenerisiIzvjestaj";
            btnGenerisiIzvjestaj.Size = new Size(236, 35);
            btnGenerisiIzvjestaj.TabIndex = 2;
            btnGenerisiIzvjestaj.Text = "GENERIŠI IZVJEŠTAJ";
            btnGenerisiIzvjestaj.UseVisualStyleBackColor = false;
            btnGenerisiIzvjestaj.Click += btnGenerisiIzvjestaj_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            label1.Location = new Point(16, 12);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(170, 25);
            label1.TabIndex = 1;
            label1.Text = "PREGLED JELA";
            // 
            // frmPregledJelaUR
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmPregledJelaUR";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmPregledJelaUR";
            Load += frmPregledJelaUR_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCategory).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLogOut).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbAccount).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbMeal).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvJelo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pbCategory;
        private PictureBox pbLogOut;
        private PictureBox pbAccount;
        private PictureBox pbMeal;
        private Panel panel2;
        private Panel panel3;
        private Button btnDodajJelo;
        private Button btnGenerisiIzvjestaj;
        private Label label1;
        private DataGridView dgvJelo;
        private Label label2;
        private TextBox txtNaziv;
        private PictureBox pbOrders;
        private DataGridViewTextBoxColumn Naziv;
        private DataGridViewTextBoxColumn Sastav;
        private DataGridViewTextBoxColumn Cijena;
        private DataGridViewTextBoxColumn Kategorija;
        private DataGridViewTextBoxColumn Ocjena;
        private DataGridViewImageColumn Slika;
    }
}