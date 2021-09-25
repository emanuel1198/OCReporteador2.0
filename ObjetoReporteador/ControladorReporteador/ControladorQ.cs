using ModeloReporteador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
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

        public string[] items(string tabla, string campo1, string campo2)
        {
            string[] Items = con.llenarCmb(tabla, campo1, campo2);
            return Items;
        }

        public DataTable enviar(string tabla, string campo1, string campo2)
        {
            var dt1 = con.obtener(tabla, campo1, campo2);
            return dt1;
        }

        Consultas cons = new Consultas();

        public DataTable llenarTbl(string tabla)
        {
            OdbcDataAdapter dt = cons.llenarTbl(tabla);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }

        public void data(string tabla)
        {
            string cadena = @"SELECT * FROM provisional.reportes;";            
            con.dataGrid(tabla, cadena);
            
        }

    }
}
