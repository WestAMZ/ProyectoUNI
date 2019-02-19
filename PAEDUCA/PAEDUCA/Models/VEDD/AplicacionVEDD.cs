using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class AplicacionVEDD
    {
        [Key]
        public int IdAplicacionVEDD { set; get; }
        public DateTime FechaAplicacion { set; get; }
        [ForeignKey("ProgramacionVEDD")]
        public int IdProgramacionVEDD { set;get;}
        [Column("IdProgramacionVEDD")]
        public virtual ProgramacionVEDD ProgramacionVEDD { set; get; }

    }
}