using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class AspectoVEDD
    {
        [Key]
        public int IdAspecto { set; get; }
        public Boolean Estado { set; get; }
        public virtual ICollection<CriterioVEDD> CriteriosVED { set; get; }
    }
}