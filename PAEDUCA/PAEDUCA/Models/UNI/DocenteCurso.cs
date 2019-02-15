using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class DocenteCurso
    {
        [Key]
        public int IdDocenteCurso { set; get; }
        public bool Estado { set; get; }
        [ForeignKey("Docente")]
        public int IdDocente { set; get; }
        [ForeignKey("Curso")]
        public int IdCurso { set; get; }
        public Docente Docente { set; get; }
        public Curso Curso { set; get; }
    }
}