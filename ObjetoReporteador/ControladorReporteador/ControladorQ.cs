using ModeloReporteador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorReporteador
{
    public class ControladorQ
    {
        Consultas con = new Consultas();
        public void Actualizar(string nombre, string ruta, string departamento, string estado, string id)
        {
            int estadofinal;
            string Vis = "Visible";

            if (estado.Equals(Vis))
            {
                estadofinal = 1;
            }
            else
            {
                estadofinal = 0;
            }

            string cadena = "UPDATE reportes SET " +
                "nombreReporte = '"+ nombre +"', " +
                "rutaReporte = '"+ ruta +"', " +
                "Departamento = '"+ departamento +"', " +
                "estado = '"+estadofinal+"' " +
                "WHERE (idReporte = '"+ id +"');";
            con.Guardar(cadena);
        }
    }
}
