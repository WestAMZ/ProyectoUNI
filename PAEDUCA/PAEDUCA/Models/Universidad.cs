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
        [Required,Column(TypeName = "varchar"), MaxLength(100)]
        public String Nombre { set; get; }
        public byte[] Logo { set; get; }
    }
}