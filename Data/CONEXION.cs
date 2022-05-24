using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace UsuariosApp_CSharp.Data
{
    internal static class CONEXION
    {
        public static SqlConnection conexion = new SqlConnection(@"Data source=DESKTOP-BN6C3P6; Initial Catalog=UsuariosDB; Integrated Security=True;");
        public static void abrir()
        {
            if(conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }          
        }
        public static void cerrar()
        {
            if(conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}
