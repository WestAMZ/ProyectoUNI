using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class AplicacionAAC
    {
        [Key]
        public int IdAplicacionaACC { set; get; }
        public DateTime FechaAplicacion { set; get; }
        public virtual Docente DocenteAcompañante { set; get; }
        public virtual Docente DocenteEvaluado { set; get; }

    }
}