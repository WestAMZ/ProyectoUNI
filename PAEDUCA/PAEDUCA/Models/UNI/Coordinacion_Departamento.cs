using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class CoordinacionDepartamento
    {
        [Key]
        public int IdCoordinacion_Departamento { set; get; }
        public string NombreCoordinacion_Departamento { set; get; }

        public string IdSedeFacultad { set; get; }
        public virtual SedeFacultad SedeFacultad { set; get; }

    }
}