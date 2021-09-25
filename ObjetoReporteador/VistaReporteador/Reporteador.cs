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
    public partial class Reporteador : Form
    {
        public Reporteador()
        {
            InitializeComponent();
            dataGrid();
        }
        //Funciones
        public void activarTextBox()
        {
            textBoxID.Enabled = true;
            textBoxNombre.Enabled = true;
            textBoxRuta.Enabled = true;
            textBoxDepartamento.Enabled = true;
            comboBoxEstado.Enabled = true;
        }

        public void desactivarTextBox()
        {
            textBoxID.Enabled = false;
            textBoxNombre.Enabled = false;
            textBoxRuta.Enabled = false;
            textBoxDepartamento.Enabled = false;
            comboBoxEstado.Enabled = false;
        }

        public void cleanTextBox()
        {
            textBoxID.Text = " ";
            textBoxNombre.Text = " ";
            textBoxRuta.Text = " ";
            textBoxDepartamento.Text = " ";
            comboBoxEstado.Text = " ";
        }

        public void dataGrid()
        {
            /*string cadena = @"SELECT * FROM provisional.reportes;";
            OdbcDataAdapter consulta = new OdbcDataAdapter(cadena, cn.conexion());
            DataTable dt = new DataTable();
            consulta.Fill(dt);
            dataGridView1.DataSource = dt;*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ControladorQ cq = new ControladorQ();

            //string[] datos_guard = { textBoxNombre.Text,textBoxRuta.Text, textBoxDepartamento.Text, comboBoxEstado.Text, textBoxID.Text };

            /*for (int i=0; i<=4; i++) {
                bt.Guardar(datos_guard[i]);
            }*/

            cq.Actualizar(textBoxNombre.Text, textBoxRuta.Text, textBoxDepartamento.Text, comboBoxEstado.Text, textBoxID.Text);

            //string cadena = "UPDATE reportes SET nombreReporte='" + textBoxNombre.Text + "', rutaReporte='" + textBoxRuta.Text + "', Departamento='" + textBoxDepartamento.Text + "', estado='" + est

            //@"VALUES ('"+ textBoxNombre+"' , '"+textBoxRuta+"','"+textBoxDepartamento+"','"+estado+"');";

            cleanTextBox();
            desactivarTextBox();
            dataGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmEliminar eli = new frmEliminar();
            eli.Show();
            dataGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            activarTextBox();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxRuta.Text = openFileDialog.FileName;
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGrid();
        }
    }
}
