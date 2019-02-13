using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class Sede_Facultad
    {
        [Key]
        public int IdSede_Facultad { set; get; }
        [Required,StringLength(200)]
        public string NombreSede_Facultad { set; get; }
        [StringLength(30)]
        public string Tipo { set; get;}
        [StringLength(200)]
        public string Web { set; get; }
  

        [Required,ForeignKey("Recinto")]
        public int IdRecinto { set; get; }
        public Recinto Recinto { set; get; }

    }
}