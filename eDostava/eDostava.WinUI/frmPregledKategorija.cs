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
    public partial class frmPregledKategorija : Form
    {
        public APIService KategorijaService { get; set; } = new APIService("Kategorija");
        public APIService KorisniciService { get; set; } = new APIService("Korisnik");
        public APIService RestoranService { get; set; } = new APIService("Restoran");

        public frmPregledKategorija()
        {
            InitializeComponent();
            dgvKategorije.AutoGenerateColumns = false;
        }

        private async void frmPregledKategorija_Load(object sender, EventArgs e)
        {
            await RefreshDataAsync();
        }

        private void pbMeal_Click(object sender, EventArgs e)
        {
            frmPregledJelaUR frmPregledJelaUR = new frmPregledJelaUR();
            frmPregledJelaUR.Show();
            this.Close();
        }

        public async Task RefreshDataAsync()
        {
            var searchObject = new KategorijaSearchObject();
            searchObject.NazivGT = txtNaziv.Text;


            var korisnici = await KorisniciService.GetKorisnici();
            var loggedInUser = korisnici.FirstOrDefault(x => x.KorisnickoIme == APIService.userName);
            var restoran = await RestoranService.GetRestaurantByKorisnikId(loggedInUser.KorisnikId);

            searchObject.RestoranId = restoran.RestoranId;

            var kategorija = await KategorijaService.Get<List<Kategorija>>(searchObject);
            kategorija = kategorija.Where(x => x.RestoranId == restoran.RestoranId).ToList();

            dgvKategorije.DataSource = kategorija;
        }

        private async void txtNaziv_TextChanged(object sender, EventArgs e)
        {
            await RefreshDataAsync();
        }

        private void btnDodajKategoriju_Click(object sender, EventArgs e)
        {
            frmDodajKategoriju frm = new frmDodajKategoriju();
            frm.ShowDialog();
        }

        private void dgvKategorije_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var kategorija = dgvKategorije.SelectedRows[0].DataBoundItem as Kategorija;

            frmDodajKategoriju frm = new frmDodajKategoriju(kategorija);
            frm.ShowDialog();
        }

        private void pbAccount_Click(object sender, EventArgs e)
        {
            frmKorisniciProfil frm = new frmKorisniciProfil();
            frm.Show();
            this.Close();
        }

        private void pbLogOut_Click(object sender, EventArgs e)
        {
            frmPrijava frm = new frmPrijava();
            frm.Show();
            this.Close();
        }

        private async void btnGenerisiIzvjestaj_Click(object sender, EventArgs e)
        {
            var searchObject = new KategorijaSearchObject();
            searchObject.NazivGT = txtNaziv.Text;

            var kategorija = await KategorijaService.Get<List<Kategorija>>(searchObject);

            var korisnici = await KorisniciService.GetKorisnici();
            var loggedInUser = korisnici.FirstOrDefault(x => x.KorisnickoIme == APIService.userName);
            var restoran = await RestoranService.GetRestaurantByKorisnikId(loggedInUser.KorisnikId);

            kategorija = kategorija.Where(x => x.RestoranId == restoran.RestoranId).ToList();

            frmIzvjestajKategorija frmIzvjestajKategorija = new frmIzvjestajKategorija(kategorija);
            frmIzvjestajKategorija.ShowDialog();
        }

        private void pbOrders_Click(object sender, EventArgs e)
        {
            frmPregledNarudzbi frmPregledNarudzbi = new frmPregledNarudzbi();
            frmPregledNarudzbi.Show();
            this.Close();
        }

        private void pbCategory_Click(object sender, EventArgs e)
        {
        }
    }
}
