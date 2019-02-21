using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class ProgramacionVEDD
    {
        [Key]
        public int IdProgramacionVED { set; get; }
        public DateTime FechaAplicacion { set; get; }
        public TimeSpan  HoraInicio { set; get; }
        public TimeSpan HoraFin { set; get; }
        public int IdPlanificacionGeneral { set; get; }
        [Column("IdPlanificacionGeneral")]
        public PlanificacionGeneral PlanificacionGeneral { set; get; }
        [ForeignKey("Curso")]
        public int IdCurso { set; get; }
        public Curso Curso { set; get; }
    }
}