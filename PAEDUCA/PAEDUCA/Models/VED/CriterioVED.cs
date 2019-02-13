using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class CriterioVED
    {
        [Key]
        public int IdCriterioVED { set; get; }
        [Required,StringLength(350)]
        public string Criterio { set; get; }
        [DisplayFormat(NullDisplayText = "Seleccione Visualización")]
        public TipoVisualizacion TipoVisualizacion { set; get; }
        [DisplayFormat(NullDisplayText = "Seleccione Visualización")]
        public TipoValor TipoValor { set; get; }
        public Boolean Estado { set; get; }

        [ForeignKey("AspectoVED")]
        public int IdAspectoVED { set; get; }
        public virtual AspectoVED AspectoVED { set; get; }
        
    }
}