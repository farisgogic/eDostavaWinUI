using eDostava.Model;
using eDostava.Model.SearchObjects;
using Flurl.Util;
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
    public partial class frmPregledJelaUR : Form
    {
        public APIService JeloService { get; set; } = new APIService("Jelo");
        public APIService KorisniciService { get; set; } = new APIService("Korisnik");
        public APIService RestoranService { get; set; } = new APIService("Restoran");


        public frmPregledJelaUR()
        {
            InitializeComponent();
            dgvJelo.AutoGenerateColumns = false;
            dgvJelo.RowTemplate.Height = 100;

        }

        private void btnDodajJelo_Click(object sender, EventArgs e)
        {
            frmDodajJeloUR frmDodajJeloUR = new frmDodajJeloUR();
            frmDodajJeloUR.ShowDialog();
        }

        private async void frmPregledJelaUR_Load(object sender, EventArgs e)
        {
            await RefreshData();
            this.Activate();
        }

        public async Task RefreshData()
        {
            var korisnici = await KorisniciService.GetKorisnici();
            var loggedInUser = korisnici.FirstOrDefault(x => x.KorisnickoIme == APIService.userName);
            var restoran = await RestoranService.GetRestaurantByKorisnikId(loggedInUser.KorisnikId);


            var searchObject = new JeloSearchObject();
            searchObject.NazivGT = txtNaziv.Text;
            searchObject.IncludeKategorija = true;
            searchObject.RestoranId = restoran.RestoranId;

            var jelo = await JeloService.Get<List<Jelo>>(searchObject);

            jelo = jelo.Where(x => x.RestoranId == restoran.RestoranId).ToList();

            dgvJelo.DataSource = jelo;
        }

        private void pbCategory_Click(object sender, EventArgs e)
        {
            frmPregledKategorija frmPregledKategorija = new frmPregledKategorija();
            frmPregledKategorija.Show();
            this.Close();
        }

        private async void txtNaziv_TextChanged(object sender, EventArgs e)
        {
            await RefreshData();
        }

        private void dgvJelo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var jelo = dgvJelo.SelectedRows[0].DataBoundItem as Jelo;

            frmDodajJeloUR frmDodajJeloUR = new frmDodajJeloUR(jelo);
            frmDodajJeloUR.ShowDialog();
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
            var searchObject = new JeloSearchObject();
            searchObject.NazivGT = txtNaziv.Text;
            searchObject.IncludeKategorija = true;

            var jelo = await JeloService.Get<List<Jelo>>(searchObject);

            var korisnici = await KorisniciService.GetKorisnici();
            var loggedInUser = korisnici.FirstOrDefault(x => x.KorisnickoIme == APIService.userName);
            var restoran = await RestoranService.GetRestaurantByKorisnikId(loggedInUser.KorisnikId);

            jelo = jelo.Where(x => x.RestoranId == restoran.RestoranId).ToList();

            frmIzvjestajJela frmIzvjestajJela = new frmIzvjestajJela(jelo);
            frmIzvjestajJela.ShowDialog();
        }

        private void pbOrders_Click(object sender, EventArgs e)
        {
            frmPregledNarudzbi frmPregledNarudzbi = new frmPregledNarudzbi();
            frmPregledNarudzbi.Show();
            this.Close();
        }

        private void pbMeal_Click(object sender, EventArgs e)
        {

        }

    }
}
