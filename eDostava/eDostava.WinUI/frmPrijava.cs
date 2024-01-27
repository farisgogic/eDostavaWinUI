using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDostava.WinUI
{
    public partial class frmPrijava : Form
    {
        private readonly APIService service = new APIService("Korisnik");
        public frmPrijava()
        {
            InitializeComponent();
        }

        private async void btnPrijava_Click(object sender, EventArgs e)
        {
            APIService.userName = txtUsername.Text;
            APIService.password = txtLozinka.Text;

            try
            {
                var result = await service.Get<dynamic>();

                frmKorisniciProfil frm = new frmKorisniciProfil();
                frm.Show();
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
            catch (Exception)
            {

                MessageBox.Show("Pogresno korisnicko ime ili lozinka");
            }
        }
        private void frmPrijava_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnPrijava;
        }

        private void btnRegistracija_Click(object sender, EventArgs e)
        {
            frmRegistracija frm = new frmRegistracija();
            frm.Show();
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }
    }
}
