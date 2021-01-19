using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaClinico.Models
{
    public class Enfermedad
    {
        public int id { get; set; }
        [Required]
        public String nombre_enfermedad { get; set; }
        [Required]
        public String descripcion { get; set; }
    }

    public class EnfermedadPaciente
    {
        public int ID { get; set; }
        [Required]
        public int ID_PACIENTE { get; set; }
        [Required]
        public int ID_ENFERMEDAD { get; set; }
        [Required]

        public string NOMBRE_ENFERMEDAD { get; set; }

    }


}