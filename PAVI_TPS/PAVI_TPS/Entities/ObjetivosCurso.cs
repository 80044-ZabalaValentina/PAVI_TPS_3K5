using System;
using System.Collections.Generic;
using System.Text;
using TPS_PAVI.Entidades;

namespace TPS_PAVI.Entities
{
    public class ObjetivosCurso
    {
        public Objetivo Objetivo{ get; set; }
        public Curso Curso { get; set; }
        public int Puntos { get; set; }

        public int Borrado { get; set; }

        public int IdObjetivo
        {
            get
            {
                return Objetivo.IdObjetivo;
            }
        }

        public int IdCurso
        {
            get
            {
                return Curso.IdCurso;
            }
        }
    }
}
