using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModeloReporteador
{
    public class Consultas
    {
        clsConexion cn = new clsConexion();
        public void Guardar(string cadena)
        {
            try
            {
                // @"UPDATE reportes SET nombreReporte='" + nombre + @"', rutaReporte='" + ruta + "', Departamento='" + departamento + "' estado='" + estadofinal + "', where idReporte='" + id + "'";
                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                MessageBox.Show("Guardado");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en Capa Modelo --> Consultas: "+e);
            }
        }
    }
}
