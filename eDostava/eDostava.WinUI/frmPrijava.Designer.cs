namespace eDostava.WinUI
{
    partial class frmPrijava
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrijava));
            label1 = new Label();
            label2 = new Label();
            txtUsername = new TextBox();
            txtLozinka = new TextBox();
            btnPrijava = new Button();
            pictureBox1 = new PictureBox();
            btnRegistracija = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(46, 147);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(133, 24);
            label1.TabIndex = 0;
            label1.Text = "Korisnicko Ime";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(46, 233);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(74, 24);
            label2.TabIndex = 1;
            label2.Text = "Lozinka";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(50, 180);
            txtUsername.Margin = new Padding(4, 3, 4, 3);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(185, 23);
            txtUsername.TabIndex = 2;
            // 
            // txtLozinka
            // 
            txtLozinka.Location = new Point(50, 267);
            txtLozinka.Margin = new Padding(4, 3, 4, 3);
            txtLozinka.Name = "txtLozinka";
            txtLozinka.PasswordChar = '*';
            txtLozinka.Size = new Size(185, 23);
            txtLozinka.TabIndex = 3;
            // 
            // btnPrijava
            // 
            btnPrijava.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnPrijava.Location = new Point(80, 325);
            btnPrijava.Margin = new Padding(4, 3, 4, 3);
            btnPrijava.Name = "btnPrijava";
            btnPrijava.Size = new Size(113, 43);
            btnPrijava.TabIndex = 4;
            btnPrijava.Text = "Prijava";
            btnPrijava.UseVisualStyleBackColor = true;
            btnPrijava.Click += btnPrijava_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(50, 14);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(175, 114);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // btnRegistracija
            // 
            btnRegistracija.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegistracija.Location = new Point(59, 378);
            btnRegistracija.Margin = new Padding(4, 3, 4, 3);
            btnRegistracija.Name = "btnRegistracija";
            btnRegistracija.Size = new Size(145, 43);
            btnRegistracija.TabIndex = 6;
            btnRegistracija.Text = "Registruj se";
            btnRegistracija.UseVisualStyleBackColor = true;
            btnRegistracija.Click += btnRegistracija_Click;
            // 
            // frmPrijava
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkTurquoise;
            ClientSize = new Size(276, 443);
            Controls.Add(btnRegistracija);
            Controls.Add(pictureBox1);
            Controls.Add(btnPrijava);
            Controls.Add(txtLozinka);
            Controls.Add(txtUsername);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmPrijava";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Prijava";
            Load += frmPrijava_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtUsername;
        private TextBox txtLozinka;
        private Button btnPrijava;
        private PictureBox pictureBox1;
        private Button btnRegistracija;
    }

}
