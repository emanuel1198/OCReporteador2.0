using ControladorReporteador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Windows.Forms.ComponentModel;
namespace VistaReporteador
{
    public partial class ReporteadorUsuario : Form
    {
        //Luis Reyes 0901-15-3121
        public ReporteadorUsuario()
        {
            InitializeComponent();
            actualizardatagriew();   //Aqui inciciamos la funcion actulizardatagriew() para que salgan los datos de la BD en el datagriew

        }
        ControladorQ sn = new ControladorQ(); // Aqui creamos un nuevo objero de ControladorQ con el nombre sh
        String tabla = "reportes"; // Aqui le asignamos a la variable tabla reportes que es el nombre de nuestra tabla
        public void actualizardatagriew() // Creamos una nueva funcion para llenar el datagriew con los datos de la BD reportes
        {
            DataTable dt = sn.llenarTbl(tabla); // iniciamos un objero DataTable que es la estructura del codigo de acceso a los datos de las tablas con la funcion llenarTb1
            dataGridView1.DataSource = dt; //esta linea de codigo el modelo que nos permite en enlase de datos de window forms 

        }
        public void busqueda() // Creamos una funcion para hacer la busqueda en la BD reportes
        {
            DataTable db = sn.llenarTb2(txtBusqueda.Text); // Iniciamos un objero DataTable = a la funicon llenarTb2 y le mandamos el dato que queremos que buscar que esta txtBusqueda
            dataGridView1.DataSource = db; // luego creamos el modelo DataSource que nos va a permitir crear un enlace de datos con widows forms 
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            busqueda();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtRuta.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString(); // cuando el usuario le da click en la fila del reporte que quiere ver se va la ruta del reporte al TxtReporte.Text 

        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            string r = txtRuta.Text;  // creamos una variable string r que seria = al dato que esta TxtReporte que es la ruta del reporte
            frmReporteAdm b = new frmReporteAdm(r); // Aqui creamos un nuevo objeto de Boton que le mandamos el dato que esta en la variable r
            b.Show(); // ahora llamamos al formulario para mostrar el reporte
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            actualizardatagriew();
        }
    }
}
