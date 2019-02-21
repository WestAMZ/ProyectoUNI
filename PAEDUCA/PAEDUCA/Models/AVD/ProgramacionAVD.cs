using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class ProgramacionAVD
    {
        [Key]
        public int IdProgramacionAVD { get; set; }
        public DateTime FechaAplicacion { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public int IdPlanificacionGeneral { set; get; }
        [Column("IdPlanificacionGeneral")]
        public PlanificacionGeneral PlanificacionGeneral { set; get; }
        [ForeignKey("Docente")]
        public int IdDocente { get; set; } 
        public Docente Docente { get; set; }
    }
}