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
    public partial class frmUrediNarudzbu : Form
    {
        public APIService NarudzbaService { get; set; } = new APIService("Narudzba");
        frmPregledNarudzbi frm = (frmPregledNarudzbi)Application.OpenForms["frmPregledNarudzbi"];


        private Narudzba? narudzba;

        public frmUrediNarudzbu(Narudzba? narudzba)
        {
            InitializeComponent();
            this.narudzba = narudzba;
            dgvStavke.AutoGenerateColumns = false;
        }

        private void frmUrediNarudzbu_Load(object sender, EventArgs e)
        {
            txtBrojNarudzbe.Text = narudzba.BrojNarudzbe;
            txtKupac.Text = narudzba.KupacIme;


            dgvStavke.DataSource = narudzba.NarudzbaStavke.ToList();
        }

        private async void btnPrihvati_Click(object sender, EventArgs e)
        {
            if (narudzba.Stanje == 0)
            {
                narudzba.Stanje = 1;
            }
            else if (narudzba.Stanje == 1)
            {
                narudzba.Stanje = 2; 
            }
            else
            {
                return;
            }

            await NarudzbaService.Update<Narudzba>(narudzba.NarudzbaId, new NarudzbaUpdateRequest { StatusNarudzbeId = narudzba.Stanje });

            await frm.RefreshData();

            this.Close();
        }
    }
}
