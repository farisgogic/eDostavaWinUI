using eDostava.Model;
using Microsoft.Reporting.WinForms;

namespace eDostava.WinUI
{
    public partial class frmIzvjestajJela : Form
    {
        private List<Jelo> jelo;

        public frmIzvjestajJela(List<Jelo> jelo)
        {
            InitializeComponent();
            this.jelo = jelo;

        }


        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void frmIzvjestajJela_Load_1(object sender, EventArgs e)
        {
            reportViewer2.LocalReport.ReportPath = @"C:\Users\User\OneDrive\Desktop\eDostava\eDostava\eDostava.WinUI\rptJelo.rdlc";
            //var rpc = new ReportParameterCollection();
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "dsJelo";
            rds.Value = jelo;
            reportViewer2.LocalReport.DataSources.Add(rds);
            //reportViewer1.LocalReport.SetParameters(rpc);
            
            reportViewer2.RefreshReport();
        }
    }
}
