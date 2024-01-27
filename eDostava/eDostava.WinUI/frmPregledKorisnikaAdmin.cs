using eDostava.Model;
using eDostava.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDostava.WinUI
{
    public partial class frmPregledKorisnikaAdmin : Form
    {
        public APIService KorisniciService { get; set; } = new APIService("Korisnik");
        public frmPregledKorisnikaAdmin()
        {
            InitializeComponent();
            dgvKorisnici.AutoGenerateColumns = false;
        }

        private async Task RefreshDataAsync()
        {
            var searchObject = new KorisnikSearchObject();
            searchObject.korisnickoIme = txtKorisnickoIme.Text;
            searchObject.IncludeRoles = true;

            var list = await KorisniciService.Get<List<Korisnik>>(searchObject);
            dgvKorisnici.DataSource = list;
        }

        private async void frmPregledKorisnikaAdmin_Load(object sender, EventArgs e)
        {
             await RefreshDataAsync();
        }

        private async void txtKorisnickoIme_TextChanged(object sender, EventArgs e)
        {
            await RefreshDataAsync();
        }

        private void pbRestaurant_Click_1(object sender, EventArgs e)
        {
            frmPregledPoslovnicaAdmin frmPregledPoslovnicaAdmin = new frmPregledPoslovnicaAdmin();
            frmPregledPoslovnicaAdmin.Show();
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void pbLogOut_Click(object sender, EventArgs e)
        {
            frmPrijava frm = new frmPrijava();
            frm.Show();
            this.Close();
        }
    }
}
