using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class AspectoAAC
    {
        [Key]
        public int IdAspectoACC { get; set; }
        [StringLength(150)]
        public string Nombre { set; get; }
        public bool Estado { get; set; }
        public virtual ICollection<CriterioAAC> CriterioACC { get; set; }
    }
}



