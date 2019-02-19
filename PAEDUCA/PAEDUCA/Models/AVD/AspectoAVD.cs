using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class AspectoAVD
    {
        [Key]
        public int IdAspectoAVD { get; set; }
        [StringLength(150)]
        public string Nombre { set; get; }
        public Boolean Estado { get; set; }
        public virtual ICollection<CriterioAVD> CriterioAVD { get; set; }
    }
}