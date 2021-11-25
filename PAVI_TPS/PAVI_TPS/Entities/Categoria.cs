using System;
using System.Collections.Generic;
using System.Text;

namespace TPS_PAVI.Entidades
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; }
        public int Borrado { get; set; }

        public override string ToString()
        {
            return NombreCategoria;
        }

    }
}
