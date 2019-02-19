using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class Asignatura
    {
        //Tipo = Básica Especifica , Profecionalizante , Básica,General
        [Key]
        public int IdAsignatura { set; get; }
        public string Nombre { set; get; }
        [StringLength(30)]
        public string Tipo { set; get; }
        public int Creditos { set; get; }
        public virtual ICollection<CarreraAsignatura> CarrerasAsignaturas { set; get; }
    }
}