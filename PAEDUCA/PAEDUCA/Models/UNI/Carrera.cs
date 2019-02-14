using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class Carrera
    {
        [Key]
        public int IdCarrera { set; get; }
        public string NombreCarrera { set; get; }
        public int CantidadSemestres { set; get; }
        public virtual ICollection<CarreraSedeFacultad> CarreraSedeFacultad { set; get; }
    }
}