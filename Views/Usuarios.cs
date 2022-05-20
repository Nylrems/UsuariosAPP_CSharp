using System;
using System.Drawing;
using System.Windows.Forms;
using UsuariosApp_CSharp.Logic;
using UsuariosApp_CSharp.Data;
using System.IO;
using System.Data;

namespace UsuariosApp_CSharp.Views
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        int idusuario;

        private void button1_Click(object sender, EventArgs e)
        {
            panelUsuario.Visible = true;
            panelUsuario.Dock = DockStyle.Fill; 
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
                    mostrar_usuarios();
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
                panelUsuario.Visible = false;
                panelUsuario.Dock = DockStyle.None;
            }
        }

        private void mostrar_usuarios()
        {
            DataTable dt;
            dusuarios funcion = new dusuarios();
            dt = funcion.mostrarUsuarios();
            datalistado.DataSource = dt;
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            
            mostrar_usuarios();
        }

        private void panelUsuario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void datalistado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idusuario = Convert.ToInt32(datalistado.SelectedCells[2].Value.ToString());
            txtUsuario.Text = datalistado.SelectedCells[3].Value.ToString();
            txtContrasena.Text = datalistado.SelectedCells[4].Value.ToString();
            pictureBox2.BackgroundImage = null;
            byte[] b = (Byte[])datalistado.SelectedCells[5].Value;
            MemoryStream ms = new MemoryStream(b);
            pictureBox2.Image = Image.FromStream(ms);

            panelUsuario.Visible = true;
            panelUsuario.Dock = DockStyle.Fill;
            btnGuardar.Visible = false;
            btnGuardarCambios.Visible = true;

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panelUsuario.Visible=false;
            panelUsuario.Dock = DockStyle.None;
        }
    }
}
