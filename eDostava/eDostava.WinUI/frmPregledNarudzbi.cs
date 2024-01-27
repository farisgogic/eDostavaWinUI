using eDostava.Model;
using eDostava.Model.SearchObjects;
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
    public partial class frmPregledNarudzbi : Form
    {
        public APIService NarudzbaService { get; set; } = new APIService("Narudzba");
        public APIService KorisniciService { get; set; } = new APIService("Korisnik");
        public APIService KupciService { get; set; } = new APIService("Kupci");
        public APIService RestoranService { get; set; } = new APIService("Restoran");

        private System.Threading.Timer refreshTimer;

        public frmPregledNarudzbi()
        {
            InitializeComponent();
            dgvNarudzba.AutoGenerateColumns = false;
            refreshTimer = new System.Threading.Timer(async _ => await RefreshData(), null, TimeSpan.Zero, TimeSpan.FromSeconds(3));
        }

        private void pbAccount_Click(object sender, EventArgs e)
        {
            frmKorisniciProfil frm = new frmKorisniciProfil();
            frm.Show();
            this.Close();
        }

        private void pbMeal_Click(object sender, EventArgs e)
        {
            frmPregledJelaUR frm = new frmPregledJelaUR();
            frm.Show();
            this.Close();
        }

        private void pbCategory_Click(object sender, EventArgs e)
        {
            frmPregledKategorija frm = new frmPregledKategorija();
            frm.Show();
            this.Close();
        }

        private void pbLogOut_Click(object sender, EventArgs e)
        {
            frmPrijava frm = new frmPrijava();
            frm.Show();
            this.Close();
        }

        private async void frmPregledNarudzbi_Load(object sender, EventArgs e)
        {
            await RefreshData();
        }

        public async Task RefreshData()
        {
            var korisnici = await KorisniciService.GetKorisnici();
            var loggedInUser = korisnici.FirstOrDefault(x => x.KorisnickoIme == APIService.userName);
            var restoran = await RestoranService.GetRestaurantByKorisnikId(loggedInUser.KorisnikId);


            var searchObject = new NarudzbaSearchObject();
            searchObject.RestoranId = restoran.RestoranId;
            searchObject.BrojNarudzbe = txtNaziv.Text;

            var narudzbe = await NarudzbaService.Get<List<Narudzba>>(searchObject);

            narudzbe = narudzbe.Where(x => x.RestoranId == restoran.RestoranId).ToList().OrderByDescending(x=>x.NarudzbaId).ToList();

            foreach(var narudzba in narudzbe)
            {
                var kupac = await KupciService.GetById<Kupci>(narudzba.KupacId);
                narudzba.KupacIme = kupac.Ime;

                narudzba.RestoranNaziv = restoran.Naziv;

            }

            if (dgvNarudzba.InvokeRequired)
            {
                dgvNarudzba.Invoke(new MethodInvoker(() => dgvNarudzba.DataSource = narudzbe));
            }
            else
            {
                dgvNarudzba.DataSource = narudzbe;
            }

        }

        private async void txtNaziv_TextChanged(object sender, EventArgs e)
        {
            await RefreshData();
        }

        private void dgvNarudzba_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var narudzba = dgvNarudzba.SelectedRows[0].DataBoundItem as Narudzba;
            frmUrediNarudzbu frmUrediNarudzbu = new frmUrediNarudzbu(narudzba);
            frmUrediNarudzbu.ShowDialog();
        }

    }
}
