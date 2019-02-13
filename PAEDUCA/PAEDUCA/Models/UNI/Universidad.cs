using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PAEDUCA.Models
{
    public class Universidad
    {
        [Key]
        public int IdUniversidad { set; get; }
        [Required,Column(TypeName = "varchar"), MaxLength(200)]
        public string Nombre { set; get; }
        public string Siglas { set; get; }
        public string Eslogan { set; get; }
        public byte[] Logo { set; get; }
        public virtual ICollection<Recinto> Recintos { set; get; }
    }
}