using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class CriterioAVD:Criterio
    {
        [Key]
        public int IdCriterioAVD { get; set; }
        [ForeignKey("AspectoAVD")]
        public int IdAspectoAVD { get; set; }
        public virtual AspectoAVD AspectoAVD { get; set; }
        public virtual ICollection<DetalleAplicacionAVD> DetalleAplicacionAVD { set; get; }

        override
        public int getId()
        {
            return IdCriterioAVD;
        }
    }
}