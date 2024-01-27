namespace eDostava.WinUI
{
    partial class frmDodajKategoriju
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDodajKategoriju));
            panel1 = new Panel();
            pbOrders = new PictureBox();
            pbCategory = new PictureBox();
            pbLogOut = new PictureBox();
            pbAccount = new PictureBox();
            pbMeal = new PictureBox();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            btnSpremi = new Button();
            label1 = new Label();
            panel5 = new Panel();
            txtNazivKategorije = new TextBox();
            label2 = new Label();
            err = new ErrorProvider(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCategory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLogOut).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbAccount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMeal).BeginInit();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
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
            panel1.Location = new Point(0, -1);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(305, 502);
            panel1.TabIndex = 2;
            // 
            // pbOrders
            // 
            pbOrders.Image = (Image)resources.GetObject("pbOrders.Image");
            pbOrders.Location = new Point(104, 114);
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
            pbCategory.Location = new Point(104, 311);
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
            pbLogOut.Location = new Point(104, 410);
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
            pbAccount.Location = new Point(104, 21);
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
            pbMeal.Location = new Point(104, 210);
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
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(302, 0);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(631, 522);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Location = new Point(0, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(566, 500);
            panel3.TabIndex = 3;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(192, 255, 255);
            panel4.Controls.Add(btnSpremi);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(panel5);
            panel4.Location = new Point(302, -1);
            panel4.Name = "panel4";
            panel4.Size = new Size(563, 502);
            panel4.TabIndex = 3;
            // 
            // btnSpremi
            // 
            btnSpremi.BackColor = Color.DarkTurquoise;
            btnSpremi.FlatStyle = FlatStyle.Flat;
            btnSpremi.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnSpremi.Location = new Point(429, 455);
            btnSpremi.Margin = new Padding(4, 3, 4, 3);
            btnSpremi.Name = "btnSpremi";
            btnSpremi.Size = new Size(119, 35);
            btnSpremi.TabIndex = 4;
            btnSpremi.Text = "SPREMI";
            btnSpremi.UseVisualStyleBackColor = false;
            btnSpremi.Click += btnSpremi_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            label1.Location = new Point(11, 21);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(230, 25);
            label1.TabIndex = 3;
            label1.Text = "DODAJ KATEGORIJU";
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.BorderStyle = BorderStyle.Fixed3D;
            panel5.Controls.Add(txtNazivKategorije);
            panel5.Controls.Add(label2);
            panel5.Location = new Point(17, 53);
            panel5.Margin = new Padding(4, 3, 4, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(531, 395);
            panel5.TabIndex = 2;
            // 
            // txtNazivKategorije
            // 
            txtNazivKategorije.BackColor = Color.FromArgb(192, 255, 255);
            txtNazivKategorije.Location = new Point(34, 48);
            txtNazivKategorije.Margin = new Padding(4, 3, 4, 3);
            txtNazivKategorije.Name = "txtNazivKategorije";
            txtNazivKategorije.Size = new Size(174, 23);
            txtNazivKategorije.TabIndex = 5;
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
            // frmDodajKategoriju
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(863, 501);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Name = "frmDodajKategoriju";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmDodajKategoriju";
            Load += frmDodajKategoriju_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCategory).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLogOut).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbAccount).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbMeal).EndInit();
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)err).EndInit();
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
        private Panel panel4;
        private Label label1;
        private Panel panel5;
        private TextBox txtNazivKategorije;
        private Label label2;
        private Button btnSpremi;
        private PictureBox pbOrders;
        private ErrorProvider err;
    }
}