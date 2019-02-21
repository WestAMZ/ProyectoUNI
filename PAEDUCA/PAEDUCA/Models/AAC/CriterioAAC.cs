using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class CriterioAAC:Criterio
    {
        [Key]
        public int IdCriterioACC { get; set; }
        public int IdAspectoAAC { set; get; }
        public virtual AspectoAAC AspectoAAC { set; get; }
        public virtual ICollection<DetalleAplicacionAAC> DetalleAplicacionAAC { set; get; }

        override
        public  int getId()
        {
            return IdCriterioACC;
        }
    }
}