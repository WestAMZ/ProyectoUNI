using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class Criterio
    {
        [Required, StringLength(350)]
        public string Nombre { get; set; }
        [DisplayFormat(NullDisplayText = "Seleccione Visualización"), DisplayName("Tipo de Visualización")]
        public TipoVisualizacion TipoVisualizacion { get; set; }
        [DisplayFormat(NullDisplayText = "Seleccione Valor de Ingreso"), DisplayName("Tipo de Valor")]
        public TipoValor TipoValor { get; set; }
        public Boolean Estado { get; set; }

        public virtual int getId()
        {
            return -1;
        }
    }
}