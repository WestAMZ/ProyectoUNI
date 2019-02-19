using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class DetalleAplicacionAVD
    {
        [Key]
        public int IdDetalleAplicacion { set; get; }
        public int IdAplicacionAVD { set; get; }
        public int IdCriterioAVD { set; get; }
        [StringLength(10)]
        public string Valor { set; get; }
        [Column("IdAplicacionAVD")]
        public virtual AplicacionAVD AplicacionAVD { set; get; }
        [Column("IdCriterioVEDD")]
        public virtual CriterioAVD CriterioAVD { set; get; }
    }
}