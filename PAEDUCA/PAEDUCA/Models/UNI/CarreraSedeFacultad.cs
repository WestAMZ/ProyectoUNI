using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class CarreraSedeFacultad
    {
        [Key]
        public int IdCarreraSedeFacultad { set; get; }
        [ForeignKey("Carrera")]
        public int IdCarrera { set; get; }
        [ForeignKey("SedeFacultad")]
        public int IdSedeFacultad { set; get; }
        public SedeFacultad SedeFacultad { set; get; }
        public Carrera Carrera { set; get; }
    }
}