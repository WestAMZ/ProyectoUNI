using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    
   public enum TipoVisualizacion
    { ComboBox, CheckList, RadioButton, SpinEdit, TextArea}
    public enum TipoValor
    { SiNo, _1a5, Libre}
    public enum TipoDivision { Departamento, Coordinacion }
    public enum ValorTipo { Sede, Facultad }
}