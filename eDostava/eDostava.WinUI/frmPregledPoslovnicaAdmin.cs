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
    public partial class frmPregledPoslovnicaAdmin : Form
    {
        public APIService RestoranService { get; set; } = new APIService("Restoran");
        
        public frmPregledPoslovnicaAdmin()
        {
            InitializeComponent();
            dgvRestorani.AutoGenerateColumns = false;
            dgvRestorani.RowTemplate.Height = 100;

        }

        private void pbUsers_Click(object sender, EventArgs e)
        {
            frmPregledKorisnikaAdmin frmPregledKorisnikaAdmin = new frmPregledKorisnikaAdmin();
            frmPregledKorisnikaAdmin.Show();
        }


        private async void frmPregledPoslovnicaAdmin_Load(object sender, EventArgs e)
        {
            await RefreshDataAsync();
            this.Activate();
        }


        private async void txtNaziv_TextChanged(object sender, EventArgs e)
        {
            await RefreshDataAsync();
        }

        public async Task RefreshDataAsync()
        {
            var searchObject = new RestoranSearchObject();
            searchObject.Naziv = txtNaziv.Text;

            var list = await RestoranService.Get<List<Restoran>>(searchObject);
            dgvRestorani.DataSource = list;
        }

        private void pbUsers_Click_1(object sender, EventArgs e)
        {
            frmPregledKorisnikaAdmin frmPregledKorisnikaAdmin = new frmPregledKorisnikaAdmin();
            frmPregledKorisnikaAdmin.Show();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmPrijava frm = new frmPrijava();
            frm.Show();
            this.Close();
        }
    }
}
