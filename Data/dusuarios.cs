using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using UsuariosApp_CSharp.Logic;
using System.Windows.Forms;
using System.Data;

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
                CONEXION.abrir();
                cmd = new SqlCommand("Insertar_usuario", CONEXION.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", dt.Usuario);
                cmd.Parameters.AddWithValue("@Pass", dt.Pass);
                cmd.Parameters.AddWithValue("@Icono", dt.Icono);
                cmd.Parameters.AddWithValue("@Estado", dt.Estado);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                CONEXION.cerrar();
            }
        }

        public DataTable mostrarUsuarios()
        {
            try
            {
                CONEXION.abrir();
                cmd = new SqlCommand("mostrar_usuarios", CONEXION.conexion);

                if(cmd.ExecuteNonQuery() != 0)
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                CONEXION.cerrar();
            }
        }

        public DataTable buscar_usuarios(string parametros)
        {
            try
            {
                CONEXION.abrir();
                cmd = new SqlCommand("buscar_usuarios", CONEXION.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@buscador",parametros);

                if (cmd.ExecuteNonQuery() != 0)
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                CONEXION.cerrar();
            }
        }

        public bool editar(lusuarios dt)
        {
            CONEXION.abrir();
            cmd = new SqlCommand("editar_usuarios", CONEXION.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_usuario", dt.Idusuario);
            cmd.Parameters.AddWithValue("@Usuario", dt.Usuario);
            cmd.Parameters.AddWithValue("Pass", dt.Pass);
            cmd.Parameters.AddWithValue("@Icono", dt.Icono);
            cmd.Parameters.AddWithValue("@Estado", dt.Estado);
            if(cmd.ExecuteNonQuery() != 0)
            {
                return true;
            }
            else
            {
                return false; 
            }
        }

        public bool eliminar_usuarios(lusuarios dt)
        {
            try
            {
                CONEXION.abrir();
                cmd = new SqlCommand("eliminar_usuarios", CONEXION.conexion);
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_usuario", dt.Idusuario);
                if(cmd.ExecuteNonQuery() != 0){
                    return true;
                }else{
                    return false;
                }

            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
                return false;
            }
            finally{
                CONEXION.cerrar();
            }
        }
    }
}
