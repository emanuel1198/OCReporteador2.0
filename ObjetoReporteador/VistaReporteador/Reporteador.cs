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

namespace VistaReporteador
{
    public partial class Reporteador : Form
    {
        public Reporteador()
        {
            InitializeComponent();
            dataGrid();

            cbxModulo.Enabled = false;
            actualizardatagriew();
        
        }

        ControladorQ sn = new ControladorQ();
        String tabla = "reportes";

        public void actualizardatagriew()
        {
            DataTable dt = sn.llenarTbl(tabla);
            dataGridView1.DataSource = dt;

        }

        //Funciones
        public void activarTextBox()
        {
            textBoxID.Enabled = true;
            textBoxNombre.Enabled = true;
            textBoxRuta.Enabled = true;
            cbxModulo.Enabled = true;
            llenarse("departamentos", "IdDepartamento", "nombredepartamento");
            //comboBoxEstado.Enabled = true;
        }

        public void desactivarTextBox()
        {
            textBoxID.Enabled = false;
            textBoxNombre.Enabled = false;
            textBoxRuta.Enabled = false;
            cbxModulo.Enabled = false;
            //comboBoxEstado.Enabled = false;            
        }

        public void cleanTextBox()
        {
            textBoxID.Text = " ";
            textBoxNombre.Text = " ";
            textBoxRuta.Text = " ";
            cbxModulo.Text = " ";
            //comboBoxEstado.Text = " ";
        }

        public void dataGrid()
        {
            ControladorQ c = new ControladorQ();
            c.data(Convert.ToString(dataGridView1.DataSource));           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ControladorQ cq = new ControladorQ();

            //string[] datos_guard = { textBoxNombre.Text,textBoxRuta.Text, textBoxDepartamento.Text, comboBoxEstado.Text, textBoxID.Text };

            /*for (int i=0; i<=4; i++) {
                bt.Guardar(datos_guard[i]);
            }*/
            

            cq.Actualizar(textBoxNombre.Text, textBoxRuta.Text, "D1", "stado", textBoxID.Text);

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
            actualizardatagriew();
        }

        private void cbxModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public void llenarse(string tabla, string campo1, string campo2)
        {
            ControladorQ cn = new ControladorQ();

            cbxModulo.ValueMember = "IdDepartamento";
            cbxModulo.DisplayMember = "nombredepartamento";
            string[] items = cn.items(tabla, campo1, campo2);
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    if (items[i] != "")
                    {
                        cbxModulo.Items.Add(items[i]);
                    }
                }
            }
            var dt2 = cn.enviar(tabla, campo1, campo2);
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in dt2.Rows)
            {
                coleccion.Add(Convert.ToString(row[campo1]) + "-" + Convert.ToString(row[campo2]));
                coleccion.Add(Convert.ToString(row[campo2]) + "-" + Convert.ToString(row[campo1]));

            }
            cbxModulo.AutoCompleteCustomSource = coleccion;
            cbxModulo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbxModulo.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rbVisible_CheckedChanged(object sender, EventArgs e)
        {
            String est;
            if (rbVisible.Checked)
            {
                est = "1";
                txtEstado.Text = est;
            }
            
        }

        private void rbNovisible_CheckedChanged(object sender, EventArgs e)
        {
            String est;
            if (rbNovisible.Checked)
            {
                est = "0";
                txtEstado.Text = est;
            }
        }
    }
}
