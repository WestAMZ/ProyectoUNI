using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class CriterioVEDD
    {
        [Key]
        public int IdCriterioVEDD { set; get; }
        [Required, StringLength(350)]
        public string Criterio { set; get; }
        [DisplayFormat(NullDisplayText = "Seleccione Visualización")]
        public TipoVisualizacion TipoVisualizacion { set; get; }
        [DisplayFormat(NullDisplayText = "Seleccione Visualización")]
        public TipoValor TipoValor { set; get; }
        public Boolean Estado { set; get; }

        [ForeignKey("AspectoVED")]
        public int IdAspectoVEDD { set; get; }
        public virtual AspectoVEDD AspectoVED { set; get; }
        public virtual ICollection<AplicacionVEDDEstudiante> AplicacionVEDDEstudiante { set;get;}
    }
}