using System;
using System.Drawing;
using System.Windows.Forms;
using UsuariosApp_CSharp.Logic;
using UsuariosApp_CSharp.Data;
using System.IO;

namespace UsuariosApp_CSharp.Views
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelUsuario.Visible = true;
            btnGuardar.Visible = true;
            btnGuardarCambios.Visible = false;
            txtUsuario.Clear();
            txtContrasena.Clear();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtUsuario.Text != ""){
                if(txtContrasena.Text != "")
                {
                    insertar_usuario();
                }
                else
                {
                    MessageBox.Show("Ingrese una contraseña", "Sin contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un usuario", "Sin usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes|*.jpg;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "Cargador de imagenes";
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.BackgroundImage = null;
                pictureBox2.Image = new Bitmap(dlg.FileName);
            }
        }

        public void insertar_usuario()
        {
            lusuarios dt = new lusuarios();
            dusuarios funcion = new dusuarios();
            dt.Usuario = txtUsuario.Text;
            dt.Pass = txtContrasena.Text;
            MemoryStream ms = new MemoryStream();
            pictureBox2.Image.Save(ms,pictureBox2.Image.RawFormat);
            dt.Icono = ms.GetBuffer();
            dt.Estado = "Activo";
            if (funcion.insertar(dt))
            {
                MessageBox.Show("Usuario Registrado", "Registro correcto");
            }
        }
    }
}
