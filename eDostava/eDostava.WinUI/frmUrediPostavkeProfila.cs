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
    public partial class frmUrediPostavkeProfila : Form
    {
        public APIService KorisniciService { get; set; } = new APIService("Korisnik");
        public APIService RestoranService { get; set; } = new APIService("Restoran");

        frmKorisniciProfil frm = (frmKorisniciProfil)Application.OpenForms["frmKorisniciProfil"];

        private Korisnik _korisnik;
        private Restoran _restoran;

        public frmUrediPostavkeProfila(Korisnik korisnik)
        {
            InitializeComponent();
            _korisnik = korisnik;
        }

        private async void frmUrediPostavkeProfila_Load(object sender, EventArgs e)
        {

            if (_korisnik != null)
            {
                txtIme.Text = _korisnik.Ime;
                txtPrezime.Text = _korisnik.Prezime;
                txtEmail.Text = _korisnik.Email;
                txtTelefon.Text = _korisnik.Telefon;

                var restoran = await RestoranService.GetRestaurantByKorisnikId(_korisnik.KorisnikId);
                if (restoran != null)
                {

                    txtNaziv.Text = restoran.Naziv;
                    txtTelefon.Text = restoran.Telefon;
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
            }

            this.AcceptButton = btnSpremi;
        }

        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            _restoran = await RestoranService.GetRestaurantByKorisnikId(_korisnik.KorisnikId);

            KorisniciUpdateRequest korisniciUpdateRequest = new KorisniciUpdateRequest()
            {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text,
                Email = txtEmail.Text,
                Telefon = txtTelefon.Text,
                Lozinka = txtLozinka.Text,
                LozinkaPotvrda = txtLozinkaPotvrda.Text
            };

            byte[] imageBytes = null;

            if (pbSlikaRestorana.Image != null && pbSlikaRestorana.ImageLocation != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pbSlikaRestorana.Image.Save(ms, pbSlikaRestorana.Image.RawFormat);
                    imageBytes = ms.ToArray();
                }
            }
            else
            {
                imageBytes = _restoran.Slika;
            }
            RestoranUpdateRequest restoranUpdateRequest = new RestoranUpdateRequest()
            {
                Naziv = txtNaziv.Text,
                Opis = txtOpis.Text,
                Adresa = txtLokacija.Text,
                RadnoVrijeme = txtRadnoVrijeme.Text,
                Telefon = txtTelefon.Text,
                Slika = imageBytes
            };


            if (txtLozinka.Text != txtLozinkaPotvrda.Text)
            {
                MessageBox.Show("Lozinke se ne poklapaju");
                return;
            }

            else if(string.IsNullOrEmpty(txtLozinka.Text) || string.IsNullOrEmpty(txtLozinkaPotvrda.Text))
            {
                MessageBox.Show("Unesite lozinku i potvrdu");
                return;
            }
            
            _korisnik = await KorisniciService.Put<Korisnik>(_korisnik.KorisnikId, korisniciUpdateRequest);
            _restoran = await RestoranService.Put<Restoran>(_restoran.RestoranId, restoranUpdateRequest);


            if(_korisnik != null)
            {
                MessageBox.Show("Uspješno ažurirani podaci");
                this.Close();
                await frm.RefreshDataAsync();
            }

            else
            {
                MessageBox.Show("Greška prilikom ažuriranja podataka");
            }
        }

        private void btnUpload_Click_1(object sender, EventArgs e)
        {
            String location = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    location = dialog.FileName;

                    pbSlikaRestorana.ImageLocation = location;

                    MessageBox.Show("Slika uspjesno učitana!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void pbLogOut_Click(object sender, EventArgs e)
        {
            frmPrijava frm = new frmPrijava();
            frm.Show();
            this.Close();
        }
    }
}
