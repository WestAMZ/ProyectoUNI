using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class Carrera
    {
        public int IdCarrera { set; get; }
        public string NombreCarrera { set; get; }
        public int CantidadSemestres { set; get; }

        public int IdSede_Facultad { set; get; }
        public virtual ICollection<SedeFacultad> Sede_Facultad { set; get; }
    }
}