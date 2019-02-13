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
        //[ForeignKey("Docente")]
        //public int IdDocente { get; set; }
    }
}