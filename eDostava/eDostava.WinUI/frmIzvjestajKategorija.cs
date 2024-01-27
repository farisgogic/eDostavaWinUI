using eDostava.Model;
using Microsoft.Reporting.WinForms;
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
    public partial class frmIzvjestajKategorija : Form
    {
        private List<Kategorija> kategorija;

        public frmIzvjestajKategorija(List<Kategorija> kategorija)
        {
            InitializeComponent();
            this.kategorija = kategorija;

        }

        private void frmIzvjestajKategorija_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportPath = @"C:\Users\User\OneDrive\Desktop\eDostava\eDostava\eDostava.WinUI\rptKategorija.rdlc";
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "dsKategorija";
            rds.Value = kategorija;
            reportViewer1.LocalReport.DataSources.Add(rds);
            //reportViewer1.LocalReport.SetParameters(rpc);

            reportViewer1.RefreshReport();
        }
    }
}
