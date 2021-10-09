using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace VistaReporteador
{
    public partial class frmReporteEmp : Form
    {
        public frmReporteEmp()
        {
            InitializeComponent();
        }

        public frmReporteEmp(string t)
        {
            InitializeComponent();
            txtRuta.Text = t;
            mostrar();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
        }

        public void mostrar()
        {

            ReportDocument crystalrpt = new ReportDocument();
            crystalrpt.Load(txtRuta.Text);
            crystalReportViewer1.ReportSource = crystalrpt;
            crystalReportViewer1.Refresh();

        }

    }
}
