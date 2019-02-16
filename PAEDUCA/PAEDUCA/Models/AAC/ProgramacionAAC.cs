using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public Docente DocenteAcompañante { get; set; }
        public Docente DocenteEvalua { get; set; }
    }
}