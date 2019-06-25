using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class Persona
    {
        [Key]
        public int IdPersona { get; set; }
        [StringLength(100)]
        public string Nombres { set; get; }
        [StringLength(100)]
        public string Apellidos { set; get; }
        public Sexo Sexo { set; get; }
    }
}