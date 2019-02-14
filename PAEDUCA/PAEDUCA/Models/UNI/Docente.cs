using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class Docente
    {
        [Key]
        public int IdDocente { set; get; }
        [StringLength(40)]
        public string Nombres { set; get; }
        [StringLength(40)]
        public string Apellidos { set; get; } 
        [StringLength(10)]
        public string Sexo { set; get; }
        [StringLength(30)]
        public string TipoContratacion { set; get; }
        [StringLength(30)]
        public string Categoria { set; get; }

        [ForeignKey("DepartamentoCoordinacion")]
        public int IdDepartamentoCoordinacion { set; get; }
        public DepartamentoCoordinacion DepartamentoCoordinacion { set; get; }
    }
}