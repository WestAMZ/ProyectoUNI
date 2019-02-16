using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class AplicacionVEDDEstudiante
    {
        [Key]
        public int IdAplicacionVEDDEstudiante { set; get; }
        public int IdAplicacionVEDD { set; get; }
        public virtual AplicacionVEDD AplicacionVEDD { set; get; }
        public virtual ICollection<DetalleAplicacionVEDD> DetalleAplicacionVEDD { set; get; }
    }
}