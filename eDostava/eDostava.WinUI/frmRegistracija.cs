using eDostava.Model;
using eDostava.Model.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDostava.WinUI
{
    public partial class frmRegistracija : Form
    {
        public APIService UlogaService { get; set; } = new APIService("Uloga");
        public APIService KorisniciService { get; set; } = new APIService("Korisnik");


        public frmRegistracija()
        {
            InitializeComponent();
        }

        private async void frmRegistracija_Load(object sender, EventArgs e)
        {

            this.AcceptButton = btnRegistracija;
        }


        private void Ocisti()
        {
            txtIme.Text = "";
            txtPrezime.Text = "";
            txtEmail.Text = "";
            txtTelefon.Text = "";
            txtKorisnickoIme.Text = "";
            txtLozinka.Text = "";
            txtLozinkaPotvrda.Text = "";
        }

        private bool Validacija(Control container)
        {
            foreach(Control control in container.Controls)
            {
                if(control is TextBox textBox && string.IsNullOrEmpty(textBox.Text))
                {
                    return true;
                }
            }
            return false;
        }

        private async void btnRegistracija_Click(object sender, EventArgs e)
        {
            if (Validacija(this))
            {
                MessageBox.Show("Molimo Vas da unesete vrijednost u sva polja.", "Validacijska Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (txtLozinka.Text != txtLozinkaPotvrda.Text)
                {
                    MessageBox.Show("Lozinke se ne poklapaju!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                KorisniciInsertRequest korisniciInsertRequest = new KorisniciInsertRequest()
                {
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    Email = txtEmail.Text,
                    Telefon = txtTelefon.Text,
                    KorisnickoIme = txtKorisnickoIme.Text,
                    Lozinka = txtLozinka.Text,
                    LozinkaPotvrda = txtLozinkaPotvrda.Text,
                    Status = true,
                };

                string email = txtEmail.Text;
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);
                if (!match.Success)
                {
                    MessageBox.Show("Email nije u ispravnom formatu");
                    return;
                }

                var uposlenikUlogaList = await UlogaService.GetByName<Uloga>("uposlenik");
                if (uposlenikUlogaList.Count > 0)
                {
                    var uposlenikUloga = uposlenikUlogaList[0];
                    int uposlenikUlogaId = uposlenikUloga.UlogaId;
                    korisniciInsertRequest.UlogeIdList = new List<int> { uposlenikUlogaId };
                }

                var korisnik = await KorisniciService.Post<Korisnik>(korisniciInsertRequest);
                    
                if(korisnik != null)
                {
                    MessageBox.Show("Uposlenik uspjesno dodan!");
                    frmPrijava frmPrijava = new frmPrijava();
                    frmPrijava.Show();
                    this.Hide();
                }
            }

            Ocisti();
        }
    }
}
