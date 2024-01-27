using Accessibility;
using eDostava.Model;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDostava.WinUI
{
    public partial class frmKorisniciProfil : Form
    {
        public APIService KorisniciService { get; set; } = new APIService("Korisnik");
        public APIService RestoranService { get; set; } = new APIService("Restoran");


        public frmKorisniciProfil()
        {
            InitializeComponent();
        }

        private async void frmKorisniciProfil_Load(object sender, EventArgs e)
        {
            await RefreshDataAsync();
        }

        public async Task RefreshDataAsync()
        {
            var korisnici = await KorisniciService.GetKorisnici();
            var loggedInUser = korisnici.FirstOrDefault(x => x.KorisnickoIme == APIService.userName);

            var ID = loggedInUser.KorisnikId;
            var restoran = await RestoranService.GetRestaurantByKorisnikId(ID);


            if (loggedInUser != null)
            {
                txtIme.Text = loggedInUser.Ime;
                txtPrezime.Text = loggedInUser.Prezime;
                txtEmail.Text = loggedInUser.Email;
                txtTelefon.Text = loggedInUser.Telefon;
                cbStatus.Checked = loggedInUser.Status.GetValueOrDefault(false);

                if (restoran != null)
                {

                    txtNaziv.Text = restoran.Naziv;
                    txtTelefon.Text = loggedInUser.Telefon;
                    txtLokacija.Text = restoran.Adresa;
                    txtRadnoVrijeme.Text = restoran.RadnoVrijeme;
                    txtOpis.Text = restoran.Opis;
                    if (restoran.Slika != null && restoran.Slika.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(restoran.Slika))
                        {
                            pbSlikaRestorana.Image = Image.FromStream(ms);
                        }
                    }
                }
                else
                {
                    // No restaurant found for the logged-in user
                    MessageBox.Show("Niste dodali informacije o svom restoranu.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private async void btnUredi_Click(object sender, EventArgs e)
        {
            var korisnici = await KorisniciService.GetKorisnici();
            var loggedInUser = korisnici.FirstOrDefault(x => x.KorisnickoIme == APIService.userName);

            frmUrediPostavkeProfila frm = new frmUrediPostavkeProfila(loggedInUser);
            frm.ShowDialog();
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

        private void pbOrders_Click(object sender, EventArgs e)
        {
            frmPregledNarudzbi frmPregledNarudzbi = new frmPregledNarudzbi();
            frmPregledNarudzbi.Show();
            this.Close();
        }
    }
}
