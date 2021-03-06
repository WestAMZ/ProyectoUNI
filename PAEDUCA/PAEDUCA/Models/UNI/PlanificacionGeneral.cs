﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class PlanificacionGeneral
    {
        [Key]
        public int IdPlanificacion { set; get; }
        //Creado por
        public int Anio { set; get; }
        public Semestre Semestre { set; get; }
        public DateTime FechaCreacion { set; get; }
        public DateTime FechaFin { set; get; }
        //Nota : sujeto a cambiarse por una 3ra tabla carrera fac
        [ForeignKey("SedeFacultad")]
        public int IdSedeFacultad { set; get; }
        public virtual SedeFacultad SedeFacultad { set; get; }
    }
}