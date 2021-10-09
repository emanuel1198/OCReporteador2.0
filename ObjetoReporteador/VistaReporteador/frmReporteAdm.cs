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
    public partial class frmReporteAdm : Form
    {
        public frmReporteAdm()
        {
            InitializeComponent();            
        }

        public frmReporteAdm(String texto)
        {
            InitializeComponent();
            textBox1.Text = texto;
            mostrar();
        }

        public void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
        
      
        

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        public void Botton_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void btnmostrar_Click(object sender, EventArgs e)
        {
            
        }

        public void mostrar() {

            ReportDocument crystalrpt = new ReportDocument();
            crystalrpt.Load(@textBox1.Text);
            crystalReportViewer1.ReportSource = crystalrpt;
            crystalReportViewer1.Refresh();
        }

       
    }
}
