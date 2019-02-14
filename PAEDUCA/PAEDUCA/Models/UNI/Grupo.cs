using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class Grupo
    {
        [Key]
        public int IdGrupo { set; get; }
        [Range(1,5)]
        public int Anio { set; get; }
        [StringLength(20)]
        public string Turno { set; get; }

        [ForeignKey("Carrera")]
        public int IdCarrera { set; get; }
        public virtual Carrera Carrera { set; get; }
    }
}