namespace eDostava.WinUI
{
    partial class frmDodajJeloUR
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDodajJeloUR));
            panel1 = new Panel();
            pbOrders = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            btnSpremi = new Button();
            label1 = new Label();
            panel3 = new Panel();
            btnUpload = new Button();
            clbKstegorija = new CheckedListBox();
            pbSlikaJela = new PictureBox();
            txtSastavJela = new RichTextBox();
            txtCijena = new TextBox();
            txtNazivJela = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            err = new ErrorProvider(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbSlikaJela).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkTurquoise;
            panel1.Controls.Add(pbOrders);
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(-7, 2);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(310, 519);
            panel1.TabIndex = 0;
            // 
            // pbOrders
            // 
            pbOrders.Image = (Image)resources.GetObject("pbOrders.Image");
            pbOrders.Location = new Point(99, 119);
            pbOrders.Margin = new Padding(4, 3, 4, 3);
            pbOrders.Name = "pbOrders";
            pbOrders.Size = new Size(57, 62);
            pbOrders.SizeMode = PictureBoxSizeMode.StretchImage;
            pbOrders.TabIndex = 7;
            pbOrders.TabStop = false;
            pbOrders.Click += pbOrders_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(99, 319);
            pictureBox4.Margin = new Padding(4, 3, 4, 3);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(57, 62);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 3;
            pictureBox4.TabStop = false;
            pictureBox4.Click += pictureBox4_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(99, 216);
            pictureBox3.Margin = new Padding(4, 3, 4, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(57, 62);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(99, 428);
            pictureBox2.Margin = new Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(57, 62);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(99, 25);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(57, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(192, 255, 255);
            panel2.Controls.Add(btnSpremi);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(299, 2);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(639, 519);
            panel2.TabIndex = 1;
            // 
            // btnSpremi
            // 
            btnSpremi.BackColor = Color.DarkTurquoise;
            btnSpremi.FlatStyle = FlatStyle.Flat;
            btnSpremi.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnSpremi.Location = new Point(502, 477);
            btnSpremi.Margin = new Padding(4, 3, 4, 3);
            btnSpremi.Name = "btnSpremi";
            btnSpremi.Size = new Size(119, 35);
            btnSpremi.TabIndex = 2;
            btnSpremi.Text = "SPREMI";
            btnSpremi.UseVisualStyleBackColor = false;
            btnSpremi.Click += btnSpremi_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            label1.Location = new Point(16, 13);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(147, 25);
            label1.TabIndex = 1;
            label1.Text = "DODAJ JELO";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(btnUpload);
            panel3.Controls.Add(clbKstegorija);
            panel3.Controls.Add(pbSlikaJela);
            panel3.Controls.Add(txtSastavJela);
            panel3.Controls.Add(txtCijena);
            panel3.Controls.Add(txtNazivJela);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(22, 45);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(598, 424);
            panel3.TabIndex = 0;
            // 
            // btnUpload
            // 
            btnUpload.BackColor = Color.FromArgb(192, 255, 255);
            btnUpload.FlatStyle = FlatStyle.Flat;
            btnUpload.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpload.Location = new Point(327, 225);
            btnUpload.Margin = new Padding(4, 3, 4, 3);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(216, 30);
            btnUpload.TabIndex = 11;
            btnUpload.Text = "Upload";
            btnUpload.UseVisualStyleBackColor = false;
            btnUpload.Click += btnUpload_Click_1;
            // 
            // clbKstegorija
            // 
            clbKstegorija.CheckOnClick = true;
            clbKstegorija.FormattingEnabled = true;
            clbKstegorija.Location = new Point(34, 294);
            clbKstegorija.Name = "clbKstegorija";
            clbKstegorija.Size = new Size(174, 112);
            clbKstegorija.TabIndex = 10;
            // 
            // pbSlikaJela
            // 
            pbSlikaJela.BackColor = Color.FromArgb(192, 255, 255);
            pbSlikaJela.BorderStyle = BorderStyle.Fixed3D;
            pbSlikaJela.Location = new Point(327, 48);
            pbSlikaJela.Margin = new Padding(4, 3, 4, 3);
            pbSlikaJela.Name = "pbSlikaJela";
            pbSlikaJela.Size = new Size(216, 171);
            pbSlikaJela.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSlikaJela.TabIndex = 8;
            pbSlikaJela.TabStop = false;
            // 
            // txtSastavJela
            // 
            txtSastavJela.BackColor = Color.FromArgb(192, 255, 255);
            txtSastavJela.Location = new Point(34, 129);
            txtSastavJela.Margin = new Padding(4, 3, 4, 3);
            txtSastavJela.Name = "txtSastavJela";
            txtSastavJela.Size = new Size(174, 147);
            txtSastavJela.TabIndex = 7;
            txtSastavJela.Text = "";
            // 
            // txtCijena
            // 
            txtCijena.BackColor = Color.FromArgb(192, 255, 255);
            txtCijena.Location = new Point(327, 331);
            txtCijena.Margin = new Padding(4, 3, 4, 3);
            txtCijena.Name = "txtCijena";
            txtCijena.Size = new Size(216, 23);
            txtCijena.TabIndex = 6;
            // 
            // txtNazivJela
            // 
            txtNazivJela.BackColor = Color.FromArgb(192, 255, 255);
            txtNazivJela.Location = new Point(34, 48);
            txtNazivJela.Margin = new Padding(4, 3, 4, 3);
            txtNazivJela.Name = "txtNazivJela";
            txtNazivJela.Size = new Size(174, 23);
            txtNazivJela.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(322, 305);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(53, 20);
            label6.TabIndex = 4;
            label6.Text = "Cijena";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(322, 20);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(43, 20);
            label5.TabIndex = 3;
            label5.Text = "Slika";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(29, 103);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(58, 20);
            label3.TabIndex = 1;
            label3.Text = "Sastav";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(29, 20);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 0;
            label2.Text = "Naziv";
            // 
            // err
            // 
            err.ContainerControl = this;
            // 
            // frmDodajJeloUR
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmDodajJeloUR";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmDodajJeloUR";
            Load += frmDodajJeloUR_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbSlikaJela).EndInit();
            ((System.ComponentModel.ISupportInitialize)err).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button btnSpremi;
        private Label label1;
        private Panel panel3;
        private PictureBox pbSlikaJela;
        private RichTextBox txtSastavJela;
        private TextBox txtCijena;
        private TextBox txtNazivJela;
        private Label label6;
        private Label label5;
        private Label label3;
        private Label label2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private CheckedListBox clbKstegorija;
        private Button btnUpload;
        private PictureBox pbOrders;
        private ErrorProvider err;
    }
}