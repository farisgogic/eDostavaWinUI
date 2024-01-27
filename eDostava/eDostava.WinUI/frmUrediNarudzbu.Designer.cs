namespace eDostava.WinUI
{
    partial class frmUrediNarudzbu
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
            this.txtBrojNarudzbe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKupac = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvStavke = new System.Windows.Forms.DataGridView();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kolicina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrihvati = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStavke)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBrojNarudzbe
            // 
            this.txtBrojNarudzbe.Location = new System.Drawing.Point(109, 22);
            this.txtBrojNarudzbe.Name = "txtBrojNarudzbe";
            this.txtBrojNarudzbe.ReadOnly = true;
            this.txtBrojNarudzbe.Size = new System.Drawing.Size(162, 23);
            this.txtBrojNarudzbe.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Broj narudzbe: ";
            // 
            // txtKupac
            // 
            this.txtKupac.Location = new System.Drawing.Point(109, 51);
            this.txtKupac.Name = "txtKupac";
            this.txtKupac.ReadOnly = true;
            this.txtKupac.Size = new System.Drawing.Size(162, 23);
            this.txtKupac.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ime kupca: ";
            // 
            // dgvStavke
            // 
            this.dgvStavke.AllowUserToAddRows = false;
            this.dgvStavke.AllowUserToDeleteRows = false;
            this.dgvStavke.BackgroundColor = System.Drawing.Color.White;
            this.dgvStavke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStavke.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Naziv,
            this.Cijena,
            this.Kolicina});
            this.dgvStavke.Location = new System.Drawing.Point(12, 108);
            this.dgvStavke.Name = "dgvStavke";
            this.dgvStavke.ReadOnly = true;
            this.dgvStavke.RowTemplate.Height = 25;
            this.dgvStavke.Size = new System.Drawing.Size(497, 284);
            this.dgvStavke.TabIndex = 4;
            // 
            // Naziv
            // 
            this.Naziv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            // 
            // Cijena
            // 
            this.Cijena.DataPropertyName = "Cijena";
            this.Cijena.HeaderText = "Cijena";
            this.Cijena.Name = "Cijena";
            this.Cijena.ReadOnly = true;
            // 
            // Kolicina
            // 
            this.Kolicina.DataPropertyName = "Kolicina";
            this.Kolicina.HeaderText = "Kolicina";
            this.Kolicina.Name = "Kolicina";
            this.Kolicina.ReadOnly = true;
            // 
            // btnPrihvati
            // 
            this.btnPrihvati.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnPrihvati.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrihvati.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPrihvati.ForeColor = System.Drawing.Color.Black;
            this.btnPrihvati.Location = new System.Drawing.Point(379, 399);
            this.btnPrihvati.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPrihvati.Name = "btnPrihvati";
            this.btnPrihvati.Size = new System.Drawing.Size(129, 35);
            this.btnPrihvati.TabIndex = 13;
            this.btnPrihvati.Text = "PRIHVATI";
            this.btnPrihvati.UseVisualStyleBackColor = false;
            this.btnPrihvati.Click += new System.EventHandler(this.btnPrihvati_Click);
            // 
            // frmUrediNarudzbu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(521, 446);
            this.Controls.Add(this.btnPrihvati);
            this.Controls.Add(this.dgvStavke);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKupac);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBrojNarudzbe);
            this.Name = "frmUrediNarudzbu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUrediNarudzbu";
            this.Load += new System.EventHandler(this.frmUrediNarudzbu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStavke)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtBrojNarudzbe;
        private Label label1;
        private TextBox txtKupac;
        private Label label2;
        private DataGridView dgvStavke;
        private DataGridViewTextBoxColumn Naziv;
        private DataGridViewTextBoxColumn Cijena;
        private DataGridViewTextBoxColumn Kolicina;
        private Button btnPrihvati;
    }
}