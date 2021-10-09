using ModeloReporteador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControladorReporteador
{
    public class ControladorQ
    {
        Consultas con = new Consultas();
        public void Actualizar(string nombre, string ruta, string IdAplicacion, string estado, string id)
        {
            string exc = @"\\";
            string orgn = @"\";
            ruta = ruta.Replace(orgn, exc);
            
            string cadena = "UPDATE reportes SET " +
                "Nombre = '" + nombre +"', " +
                "Ruta = '" + ruta +"', " +
                "IdAplicacion = '" + IdAplicacion +"', " +
                "Estado = '" + estado + "' " +
                "WHERE (IdReporte = '" + id +"');";
                con.Guardar(cadena);
        }
        
        public void GuardarD(string id, string nombre, string ruta, string IdAplicacion, string estado)
        {
            string exc = @"\\";
            string orgn = @"\";
            ruta = ruta.Replace(orgn, exc);

            string cadena = "INSERT INTO Reportes VALUES('" + id + "','" + nombre + "','" + ruta + "','" + IdAplicacion + "','" + estado + "');";
                con.Guardar(cadena);
        }

        //Funcion para obtener el IdModulo
        public OdbcDataReader IdModulo(string nombreM)
        {        
            string cadena = "Select IdModulo from modulos where Nombre = '" + nombreM + "';";
            return con.IdMod(cadena);          
        }

        //Funcion para obtener el nombre del modulo en combobox
        public OdbcDataReader llenarcbxModulo()
        {
            string sql = "SELECT Nombre FROM provisional.modulos;";
            return con.llenarcbxmodulo(sql);
        }


        //Funcion para obtener el IdAplic
        public OdbcDataReader IdAplici(string nombreA)
        {
            string cadena = "Select IdAplicacion from aplicacion where Nombre = '" + nombreA + "';";
            return con.IdAplic(cadena);
        }

        //Funcion para obtener el nombre de la aplicacion en combobox
        public OdbcDataReader llenarcbxAplic()
        {
            string sql = "SELECT Nombre FROM provisional.aplicacion;";
            return con.llenarcbxAplicacion(sql);
        }

        Consultas cons = new Consultas();

        public DataTable llenarTbl(string tabla)
        {
            OdbcDataAdapter dt = cons.llenarTbl(tabla);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }
        public DataTable llenarTb2(string datob) //Aquie creamos la funcion DataTable llenarTb2 que resive el dato que esta en el variable datob
        {
            OdbcDataAdapter db = cons.llenarTb2(datob); //creamos un objeto 
            DataTable table = new DataTable();
            db.Fill(table);
            return table;
        }

        public void data(string tabla)
        {
            string cadena = @"SELECT * FROM provisional.reportes;";            
            con.dataGrid(tabla, cadena);            
        }

    }
}
