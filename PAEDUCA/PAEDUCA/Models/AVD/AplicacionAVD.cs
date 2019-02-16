using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class AplicacionAVD
    {
        [Key]
        public int IdAplicacionVEDD { set; get; }
        public DateTime FechaAplicacion { set; get; }
        [ForeignKey("Docente")]
        public int IdDocenteEvaluado { set; get; }
        public virtual Docente Docente { set; get; }
    }
}