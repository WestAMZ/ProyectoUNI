using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class Recinto
    {
        [Key]
        public int IdRecinto { set; get; }
        [Required, ForeignKey("Universidad")]
        public int IdUniversidad { set; get; }
        [Required,StringLength(200)]
        public string NombreRecinto  { get; set; }
        public Universidad Universidad { set; get; }
    }
}