using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class Curso
    {
        [Key]
        public int IdCurso { set; get; }
        [ForeignKey("Grupo")]
        public int IdGrupo { set; get; }
        [ForeignKey("Asignatura")]
        public int IdAsignatura { set; get; }
        public Semestre Semestre { set; get; }
        public int Anio { set; get; }
        public string Estado { set; get; }

        public virtual Grupo Grupo { set; get; }
        public virtual Asignatura Asignatura { set; get; }
        public virtual ICollection<DocenteCurso> DocenteCurso { set; get; }
        //public virtual CarreraSedeFacultad CarreraSedeFacultad { set; get; }
        //[ForeignKey("CarreraSedeFacultad")]
        //public int IdCarreraSedeFacultad { set; get; }

    }
}