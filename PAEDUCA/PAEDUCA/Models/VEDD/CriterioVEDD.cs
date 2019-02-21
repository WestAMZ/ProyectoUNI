using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class CriterioVEDD:Criterio
    {
        [Key]
        public int IdCriterioVEDD { set; get; }
        [ForeignKey("AspectoVED")]
        public int IdAspectoVEDD { set; get; }
        public virtual AspectoVEDD AspectoVED { set; get; }
        public virtual ICollection<DetalleAplicacionVEDD> DetalleAplicacionVEDD { set;get;}
    }
}