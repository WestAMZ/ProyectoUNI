﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using PAEDUCA.Models;

namespace PAEDUCA.Models
{
    public class Docente:Persona
    {
        [Key]
        public int IdDocente { set; get; }
        [StringLength(30)]
        public string TipoContratacion { set; get; }
        [StringLength(30)]
        public string Categoria { set; get; }

        [ForeignKey("DepartamentoCoordinacion")]
        public int IdDepartamentoCoordinacion { set; get; }
        public virtual DepartamentoCoordinacion DepartamentoCoordinacion { set; get; }
        public virtual ICollection<DocenteCurso> DocenteCurso { set; get; }
    }
}