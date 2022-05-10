using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp_CSharp.Logic
{
    class lusuarios
    {
        private int idusuario;
        private string usuario;
        private string pass;
        private byte[] icono;
        private string estado;

        public int Idusuario
        {
            get { return Idusuario; }   
            set { Idusuario = value; }
        }
        public string Usuario
        {
            get { return Usuario; }
            set { Usuario = value; }
        }
        public string Pass
        {
            get { return Pass; }
            set { Pass = value; }
        }
        private byte[] Icono
        {
            get { return Icono; }
            set { Icono = value; }
        }
        public string Estado
        {
            get { return Estado; }
            set { Estado = value; } 
        }
    }
}
