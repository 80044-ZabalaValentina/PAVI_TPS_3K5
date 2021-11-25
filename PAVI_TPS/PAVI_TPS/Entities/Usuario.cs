using System;
using System.Collections.Generic;
using System.Text;

namespace TPS_PAVI
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario {get; set;}
        public string Contraseña {get; set;}
        public Usuario()
        {

        }
        public override string ToString()
        {
            return NombreUsuario.ToString();

        }

        public Usuario(string nombre, string contraseña)
        {
            NombreUsuario = nombre;
            Contraseña = contraseña;
        }
    }
}


