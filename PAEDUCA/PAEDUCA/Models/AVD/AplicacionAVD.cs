using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models.AVD
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