using ControladorReporteador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaReporteador
{
    public partial class frmConsultaReport : Form
    {
        public frmConsultaReport()
        {
            InitializeComponent();
        }

        ControladorQ sn = new ControladorQ();
        String tabla = "reportes";
        public void actualizardatagriew()
        {
            DataTable dt = sn.llenarTbl(tabla);
            dataGridView1.DataSource = dt;
        }

        private void abrir_Click(object sender, EventArgs e)
        {
            string r = txtRuta.Text;
            frmReporteAdm b = new frmReporteAdm(r);
            b.Show();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {

        }
    }
}
