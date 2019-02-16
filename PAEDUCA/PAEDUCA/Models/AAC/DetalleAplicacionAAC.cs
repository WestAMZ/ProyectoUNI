using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class DetalleAplicacionAAC
    {
        [Key]
        public int IdDetalleAplicacion { set; get; }
        public int IdAplicacionAAC { set; get; }
        public int IdCriterioAAC { set; get; }
        [StringLength(10)]
        public string Valor { set; get; }
        public virtual AplicacionAAC AplicacionAAC { set; get; }
        public virtual CriterioAAC CriterioAAC { set; get; }

    }
}