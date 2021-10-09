using System;
using System.Collections.Generic;
using System.Data;
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
                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                MessageBox.Show("Guardado");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en Capa Modelo --> Consultas: "+e);
            }
        }


        //Funcion para obtener el IdModulo
        public OdbcDataReader IdMod(string cadena)
        {
            try
            {
                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                OdbcDataReader leer = consulta.ExecuteReader();
                return leer;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en Capa Modelo --> Consultas: " + e);
                return null;
            }
        }

        //Funcion para obtener el nombre del modulo en combobox
        public OdbcDataReader llenarcbxmodulo(string sql)
        {
            try
            {
                OdbcCommand datos = new OdbcCommand(sql, cn.conexion());
                OdbcDataReader leer = datos.ExecuteReader();
                return leer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        //Funcion para obtener el IdModulo
        public OdbcDataReader IdAplic(string cadena)
        {
            try
            {
                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                OdbcDataReader leer = consulta.ExecuteReader();
                return leer;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en Capa Modelo --> Consultas: " + e);
                return null;
            }
        }

        //Funcion para obtener el nombre de la aplicacion en combobox
        public OdbcDataReader llenarcbxAplicacion(string sql)
        {
            try
            {
                OdbcCommand datos = new OdbcCommand(sql, cn.conexion());
                OdbcDataReader leer = datos.ExecuteReader();
                return leer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public OdbcDataAdapter llenarTbl(string tabla)// metodo  que obtinene el contenio de una tabla
        {
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT * FROM " + tabla + " ;";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, con.conexion());
            return dataTable;
        }
        // Luis Reyes 0901-15-3121
        public OdbcDataAdapter llenarTb2(string datob)// metodo que obtinene de la tabla de la busqueda 
        {
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT * FROM Reportes where Nombre = '" + datob + "' ;"; // aqui ponemos la consulta de la busqueda que vallamos hacer en la BD
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, con.conexion()); // aqui creamos un objeto de OdbcDataAda y le mandamos la consulta y abrimos conecion con la BD
            return dataTable; // Aquie retorna el dataTable
        }

        clsConexion con = new clsConexion();
                
        public void dataGrid(string datos, string cadena)
        {            
            OdbcDataAdapter consulta = new OdbcDataAdapter(cadena, cn.conexion());
            DataTable dt = new DataTable();
            consulta.Fill(dt);
            datos = Convert.ToString(dt);            
        }

    }
}
