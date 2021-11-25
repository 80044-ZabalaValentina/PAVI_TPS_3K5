using System;
using System.Collections.Generic;
using System.Text;
using TPS_PAVI.Entidades;

namespace TPS_PAVI.Entities
{
    public class AvanceUsuario
    {
        public Curso Curso { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public int PorcentajeAvance { get; set; }

        public int IdCurso
        {
            get
            {
                return Curso.IdCurso;
            }
        } 

        public string NombreCurso
        {
            get
            {
                return Curso.NombreCurso;
            }
        }

        public int IdUsuario
        {
            get
            {
                return Usuario.IdUsuario;
            }
        }

        public string NombreUsuario
        {
            get
            {
                return Usuario.NombreUsuario;
            }
        }
    }
}
