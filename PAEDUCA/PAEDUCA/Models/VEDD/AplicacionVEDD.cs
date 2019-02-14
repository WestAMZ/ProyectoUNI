using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class AplicacionVEDD
    {
        [Key]
        public int IdAplicacionVEDD { set; get; }
        public DateTime FechaAplicacion { set; get; }


    }
}