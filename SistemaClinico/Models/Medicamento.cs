using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaClinico.Models
{
    public class Medicamento
    {
        public int id { get; set; }
        [Required]
        public String NOMBRE_MEDICAMENTO { get; set; }
        [Required]
        public String DESCRIPCION_MEDICAMENTO { get; set; }
        [Required]
        public int CANTIDAD { get; set; }
        [Required]
        public String PRESENTACION { get; set; }
        [Required]
        public double PRECIO_UNITARIO { get; set; }
        [Required]
        public String ESTADO { get; set; }

    }
}