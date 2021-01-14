using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaClinico.Models
{
    public class CitasPaciente
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int ID_PACIENTE { get; set; }
        [Required]
        public string FECHA { get; set; }
        [Required]
        public string HORA { get; set; }
        [Required]
        public string TURNO { get; set; }
        [Required]
        public string TIPO_CITA { get; set; }
        [Required]
        public int ID_DEPARTAMENTO { get; set; }
        [Required]
        public string DESCRIPCION { get; set; }
        [Required]
        public string ESTADO { get; set; }
    }
}