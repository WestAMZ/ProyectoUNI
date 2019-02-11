using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class Coordinacion_Departamento
    {
        [Key]
        public int IdCoordinacion_Departamento { set; get; }
        public string NombreCoordinacion_Departamento { set; get; }

        public string IdSede_Facultad { set; get; }
        public Sede_Facultad Sede_Facultad { set; get; }

    }
}