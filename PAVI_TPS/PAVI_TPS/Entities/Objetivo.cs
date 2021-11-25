using System;
using System.Collections.Generic;
using System.Text;

namespace TPS_PAVI.Entidades
{
    public class Objetivo
    {
        public int IdObjetivo { get; set; }
        public string NombreCortoObjetivo { get; set; }
        public string NombreLargoObjetivo { get; set; }
        public int Borrado { get; set; }

        public override string ToString()
        {
            return NombreLargoObjetivo;
        }
     
    }
}
