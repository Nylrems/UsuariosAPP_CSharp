using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using UsuariosApp_CSharp.Logic;
using System.Windows.Forms;

namespace UsuariosApp_CSharp.Data
{
    class dusuarios
    {
        private SqlCommand cmd = new SqlCommand();
        private int idusuario;

        public bool insertar(lusuarios dt)
        {
            try
            {

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
