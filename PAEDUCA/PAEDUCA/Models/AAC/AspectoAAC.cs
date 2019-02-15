using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class AspectoAAC
    {
        [Key]
        public int IdAspectoACC { get; set; }
        public Boolean Estado { get; set; }
        public virtual ICollection<CriterioAACC> CriterioACC { get; set; }
    }
}