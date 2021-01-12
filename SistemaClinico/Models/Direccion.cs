using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaClinico.Models
{
    public class Direccion
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string PAIS { get; set; }
        [Required]
        public string DEPARTAMENTO { get; set; }
        [Required]
        public string MUNICIPIO { get; set; }
    }
}