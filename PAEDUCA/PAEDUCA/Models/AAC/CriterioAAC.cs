using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class CriterioAAC
    {
        [Key]
        public int IdCriterioACC { get; set; }
        [Required, StringLength(350)]
        public string Criterio { get; set; }
        [DisplayFormat(NullDisplayText = "Seleccione Visualización")]
        public TipoVisualizacion TipoVisauilzacion { get; set; }
        [DisplayFormat(NullDisplayText = "Seleccione Visualización")]
        public TipoValor TipoValor { get; set; }
        public Boolean Estado { get; set; }
    }
}