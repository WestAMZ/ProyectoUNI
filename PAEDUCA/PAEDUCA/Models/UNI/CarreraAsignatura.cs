using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class CarreraAsignatura
    {
        [Key]
        public int IdCarreraAsignatura { set; get; }
        public int Semestre { set; get; }

        [ForeignKey("Carrera")]
        public int IdCarrera { set; get; }
        [ForeignKey("Asignatura")]
        public int IdAsignatura { set; get; }
        public virtual ICollection<Carrera> Carreras { set; get; }
        public virtual ICollection<Asignatura> Asignaturas { set; get; }
    }
}