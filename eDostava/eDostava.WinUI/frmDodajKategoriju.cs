using eDostava.Model;
using eDostava.Model.Request;
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
    public partial class frmDodajKategoriju : Form
    {
        public APIService KategorijaService { get; set; } = new APIService("Kategorija");
        public APIService KorisniciService { get; set; } = new APIService("Korisnik");
        public APIService RestoranService { get; set; } = new APIService("Restoran");

        frmPregledKategorija frm = (frmPregledKategorija)Application.OpenForms["frmPregledKategorija"];
        private Kategorija _kategorija;

        public frmDodajKategoriju(Kategorija kategorija = null)
        {
            InitializeComponent();
            _kategorija = kategorija;
        }


        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            bool hasValidationError = false;
            if (string.IsNullOrEmpty(txtNazivKategorije.Text))
            {
                err.SetError(txtNazivKategorije, "Naziv kategorije je obavezan");
                hasValidationError = true;
            }
            else
            {
                err.SetError(txtNazivKategorije, "");
            }

            if (hasValidationError)
            {
                return;
            }

            var korisnici = await KorisniciService.GetKorisnici();
            var loggedInUser = korisnici.FirstOrDefault(x => x.KorisnickoIme == APIService.userName);
            var restoran = await RestoranService.GetRestaurantByKorisnikId(loggedInUser.KorisnikId);

            if (_kategorija == null)
            {

                KategorijaUpsertRequest kategorijaUpsertRequest = new KategorijaUpsertRequest()
                {
                    Naziv = txtNazivKategorije.Text,
                    RestoranId = restoran.RestoranId,
                };

                var kategorija = KategorijaService.Post<Kategorija>(kategorijaUpsertRequest);
                if (kategorija != null)
                {
                    MessageBox.Show("Kategorija uspjesno dodana");
                    await frm.RefreshDataAsync();
                    this.Close();
                }
            }
            else
            {
                KategorijaUpsertRequest kategorijaUpsertRequest = new KategorijaUpsertRequest()
                {
                    Naziv = txtNazivKategorije.Text,
                    RestoranId = restoran.RestoranId,
                };

                var kategorija = KategorijaService.Put<Kategorija>(_kategorija.KategorijaId, kategorijaUpsertRequest);
                if (kategorija != null)
                {
                    MessageBox.Show("Kategorija uspjesno ažurirana");
                    await frm.RefreshDataAsync();
                    this.Close();
                }
            }
        }

        private void frmDodajKategoriju_Load(object sender, EventArgs e)
        {
            if (_kategorija != null)
            {
                txtNazivKategorije.Text = _kategorija.Naziv;
            }
        }

        private void pbLogOut_Click(object sender, EventArgs e)
        {
            frmPrijava frm = new frmPrijava();
            frm.Show();
            this.Close();
        }

        private void pbAccount_Click(object sender, EventArgs e)
        {
            frmKorisniciProfil frm = new frmKorisniciProfil();
            frm.Show();
            this.Close();
        }

        private void pbOrders_Click(object sender, EventArgs e)
        {
            frmPregledNarudzbi frmPregledNarudzbi = new frmPregledNarudzbi();
            frmPregledNarudzbi.Show();
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
    }
}
