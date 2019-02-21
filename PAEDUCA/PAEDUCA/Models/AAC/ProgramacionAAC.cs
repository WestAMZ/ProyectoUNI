using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class ProgramacionAAC
    {
        [Key]
        public int IdProgramacionACC { get; set; }
        public DateTime FechaAplicacion { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public int IdPlanificacionGeneral { set; get; }
        [Column("IdPlanificacionGeneral")]
        public PlanificacionGeneral PlanificacionGeneral { set; get; }
        [Column("IdDocenteAcompanante")]
        public Docente DocenteAcompanante { get; set; }
        [Column("IdDocenteEvaluado")]
        public Docente DocenteEvaluado { get; set; }
    }
}