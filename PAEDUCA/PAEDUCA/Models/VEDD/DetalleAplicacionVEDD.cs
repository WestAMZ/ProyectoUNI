using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class DetalleAplicacionVEDD
    {
        [Key]
        public int IdDetalleAplicacionVEDD { set; get; }
        public int IdCriterioVEDD { set; get; }
        [StringLength(10)]
        public string Valor { set; get; }
        public virtual AplicacionVEDDEstudiante AplicacionVEDDEstudiante { set; get; }
        public virtual CriterioVEDD CriterioVEDD { set; get; }

    }
}