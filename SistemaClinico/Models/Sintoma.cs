using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaClinico.Models
{
    public class Sintoma
    {
        public int id { get; set; }
        [Required]
        public String nombre { get; set; }
        [Required]
        public String descripcion { get; set; }
    }
}