using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class SedeFacultad
    {
        public enum ValorTipo { Sede,Facultad}
        [Key]
        public int IdSedeFacultad { set; get; }
        [Required,StringLength(200)]
        public string Nombre { set; get; }
        public ValorTipo Tipo { set; get;}
        [StringLength(200)]
        public string Web { set; get; }
  

        [Required,ForeignKey("Recinto")]
        public int IdRecinto { set; get; }
        public virtual Recinto Recinto { set; get; }
        public virtual  ICollection<Carrera> Carreraas { set; get; }
        public virtual ICollection<DepartamentoCoordinacion> CoordinacionDepartamento { set; get; }

    }
}