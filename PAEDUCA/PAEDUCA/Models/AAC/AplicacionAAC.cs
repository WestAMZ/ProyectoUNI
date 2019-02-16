using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public virtual ICollection<DetalleAplicacionAAC> DetalleAplicacionAAC { set; get; }

    }
}