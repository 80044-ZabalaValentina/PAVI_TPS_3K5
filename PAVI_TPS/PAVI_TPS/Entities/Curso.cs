using System;
using System.Collections.Generic;
using System.Text;

namespace TPS_PAVI.Entidades
{
    public class Curso
    {
        public int IdCurso { get; set; }
        public string NombreCurso { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaVigencia { get; set; }
        public Categoria Categoria_Curso { get; set; }
        public int Borrado { get; set; }

        public override string ToString()
        {
            return NombreCurso;
        }
    }
}
