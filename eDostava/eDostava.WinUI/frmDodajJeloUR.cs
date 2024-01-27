using eDostava.Model;
using eDostava.Model.Request;
using eDostava.Model.SearchObjects;
using System.Data;

namespace eDostava.WinUI
{
    public partial class frmDodajJeloUR : Form
    {
        public APIService JeloService { get; set; } = new APIService("Jelo");
        public APIService KategorijaService { get; set; } = new APIService("Kategorija");
        public APIService KorisniciService { get; set; } = new APIService("Korisnik");
        public APIService RestoranService { get; set; } = new APIService("Restoran");

        frmPregledJelaUR frm = (frmPregledJelaUR)Application.OpenForms["frmPregledJelaUR"];
        private Jelo _jelo;

        public frmDodajJeloUR(Jelo jelo = null)
        {
            InitializeComponent();
            _jelo = jelo;
        }


        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            bool hasValidationError = false; 

            if (string.IsNullOrEmpty(txtNazivJela.Text))
            {
                err.SetError(txtNazivJela, "Naziv jela je obavezan");
                hasValidationError = true; 
            }
            else
            {
                err.SetError(txtNazivJela, "");
            }

            if (string.IsNullOrEmpty(txtSastavJela.Text))
            {
                err.SetError(txtSastavJela, "Sastav jela je obavezan");
                hasValidationError = true;
            }
            else
            {
                err.SetError(txtSastavJela, "");
            }

            if (string.IsNullOrEmpty(txtCijena.Text))
            {
                err.SetError(txtCijena, "Cijena jela je obavezan");
                hasValidationError = true; 
            }
            else
            {
                err.SetError(txtCijena, "");
            }

            if (pbSlikaJela.Image == null)
            {
                err.SetError(pbSlikaJela, "Slika jela je obavezan");
                hasValidationError = true; 
            }
            else
            {
                err.SetError(pbSlikaJela, "");
            }

            bool hasCheckedItems = false;
            foreach (int selectedIndex in clbKstegorija.CheckedIndices)
            {
                hasCheckedItems = true;
                break;
            }
            if (!hasCheckedItems)
            {
                err.SetError(clbKstegorija, "Morate odabrati barem jednu kategoriju.");
                hasValidationError = true; 
            }
            else
            {
                err.SetError(clbKstegorija, "");
            }

            if (hasValidationError)
            {
                return;
            }


            var kategorijaList = clbKstegorija.CheckedItems.Cast<Kategorija>().ToList();
            var kategorijaListId = kategorijaList.Select(x => x.KategorijaId).ToList();

            byte[] imageBytes = null;
            if (pbSlikaJela.Image != null && pbSlikaJela.ImageLocation != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pbSlikaJela.Image.Save(ms, pbSlikaJela.Image.RawFormat);
                    imageBytes = ms.ToArray();
                }
            }
            else
            {
                imageBytes = _jelo.Slika;
            }

            double cijena;
            if (!Double.TryParse(txtCijena.Text, out cijena))
            {
                MessageBox.Show("Cijena jela mora biti broj");
                return;
            }

            var korisnici = await KorisniciService.GetKorisnici();
            var loggedInUser = korisnici.FirstOrDefault(x => x.KorisnickoIme == APIService.userName);
            var restoran = await RestoranService.GetRestaurantByKorisnikId(loggedInUser.KorisnikId);

            if (_jelo == null)
            {

                JeloUpsertRequest jeloUpsert = new JeloUpsertRequest()
                {
                    Naziv = txtNazivJela.Text,
                    Cijena = cijena,
                    Opis = txtSastavJela.Text,
                    Slika = imageBytes,
                    KategorijaId = kategorijaListId,
                    RestoranId = restoran.RestoranId
                };


                var jelo = await JeloService.Post<Jelo>(jeloUpsert);
                if (jelo != null)
                {
                    MessageBox.Show("Jelo je uspjesno dodano!");
                    await frm.RefreshData();
                    this.Close();
                }
            }
            else
            {
                kategorijaListId = kategorijaList.Select(x => x.KategorijaId).ToList();
                JeloUpsertRequest jeloUpsert = new JeloUpsertRequest
                {
                    Naziv = txtNazivJela.Text,
                    Cijena = cijena,
                    Opis = txtSastavJela.Text,
                    Slika = imageBytes,
                    KategorijaId = kategorijaListId,
                    RestoranId = restoran.RestoranId,
                };


                var updatedJelo = await JeloService.Put<Jelo>(_jelo.JeloId, jeloUpsert);
                if (updatedJelo != null)
                {
                    MessageBox.Show("Jelo je uspješno ažurirano!");
                    await frm.RefreshData();
                    this.Close();
                }
            }

        }

        private async Task LoadKategorija()
        {
            var korisnici = await KorisniciService.GetKorisnici();
            var loggedInUser = korisnici.FirstOrDefault(x => x.KorisnickoIme == APIService.userName);
            var restoran = await RestoranService.GetRestaurantByKorisnikId(loggedInUser.KorisnikId);

            var searchObject = new KategorijaSearchObject();
            searchObject.RestoranId = restoran.RestoranId;

            var kategorija = await KategorijaService.Get<List<Kategorija>>(searchObject);
            clbKstegorija.DataSource = kategorija;
            clbKstegorija.DisplayMember = "Naziv";
        }

        private async void frmDodajJeloUR_Load(object sender, EventArgs e)
        {
            await LoadKategorija();

            if (_jelo != null)
            {
                txtNazivJela.Text = _jelo.Naziv;
                txtSastavJela.Text = _jelo.Opis;
                txtCijena.Text = _jelo.Cijena.ToString();
                if (_jelo.Slika != null)
                {
                    using (MemoryStream ms = new MemoryStream(_jelo.Slika))
                    {
                        pbSlikaJela.Image = Image.FromStream(ms);
                    }
                }
                var kategorijaList = clbKstegorija.Items.Cast<Kategorija>().ToList();

                foreach (var kategorija in kategorijaList)
                {
                    if (_jelo.JeloKategorijas.Any(x => x.KategorijaId == kategorija.KategorijaId))
                    {
                        clbKstegorija.SetItemChecked(clbKstegorija.Items.IndexOf(kategorija), true);
                    }
                }
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

                    pbSlikaJela.ImageLocation = location;

                    MessageBox.Show("Slika uspjesno učitana!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmPrijava frm = new frmPrijava();
            frm.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmKorisniciProfil frmKorisniciProfil = new frmKorisniciProfil();
            frmKorisniciProfil.Show();
            this.Close();
        }

        private void pbOrders_Click(object sender, EventArgs e)
        {
            frmPregledNarudzbi frmPregledNarudzbi = new frmPregledNarudzbi();
            frmPregledNarudzbi.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmPregledJelaUR frm = new frmPregledJelaUR();
            frm.Show();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            frmPregledKategorija frm = new frmPregledKategorija();
            frm.Show();
            this.Close();
        }
    }
}
