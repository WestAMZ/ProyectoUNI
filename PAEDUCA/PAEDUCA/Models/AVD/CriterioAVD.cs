using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class CriterioAVD
    {
        [Key]
        public int IdCriterioAvd { get; set; }
        [Required,StringLength(350)]
        public string Criterio { get; set; }
        [DisplayFormat(NullDisplayText = "Seleccione Visualización")]
        public TipoVisualizacion TipoVisauilzacion { get; set; }
        [DisplayFormat(NullDisplayText = "Seleccione Visualización")]
        public TipoValor TipoValor { get; set; }
        public Boolean Estado { get; set; }

        [ForeignKey("AspectoAVD")]
        public int IdAspectoAVD { get; set; }
        public virtual AspectoAVD AspectoAVD { get; set; }
    }
}