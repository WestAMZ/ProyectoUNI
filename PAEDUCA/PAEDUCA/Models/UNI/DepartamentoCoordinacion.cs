using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class DepartamentoCoordinacion
    {
        public enum TipoDivision {Departamento,Coordinacion}
        [Key]
        public int IdDepartamentoCoordinacion { set; get; }
        [StringLength(200)]
        public string Nombre { set; get; }
        public TipoDivision Tipo { set; get; }
        [ForeignKey("SedeFacultad")]
        public int IdSedeFacultad { set; get; }
        public virtual SedeFacultad SedeFacultad { set; get; }
    }
}