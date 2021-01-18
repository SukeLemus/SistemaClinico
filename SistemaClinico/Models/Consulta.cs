using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaClinico.Models
{
    public class Consulta
    {
        public int ID { get;set; }
        public int ID_PACIENTE { get;set; }
        public int ID_PERSONAL { get;set; }
        public string FECHA { get;set; }
        public string HORA { get;set; }
        public int ID_CITAS { get;set; }
        public string DIAGNOSTICO { get;set; }

    }

    public class ConsultaPac
    {
        public int ID_CONSULTA { get; set; }
        public int ID_PACIENTE { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public string FECHA { get; set; }
        public string HORA { get; set; }
        public string TIPO_CITA { get; set; }
        public string DESCRIPCION { get; set; }
        public string DIAGNOSTICO { get; set; }

    }
    public class ConsultaSobrecargada
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public int ID_PACIENTE { get; set; }

        [Required]
        public int ID_PERSONAL { get; set; }

        [Required]
        public string FECHA { get; set; }

        [Required]
        public string HORA { get; set; }

        [Required]
        public int ID_CITAS { get; set; }

        [Required(ErrorMessage = "* El diagnóstico es obligatorio")]
        public string DIAGNOSTICO { get; set; }

        [Required]
        public int ID_CONSULTA { get; set; }

        [Required(ErrorMessage = "* Elija un medicamento (Puede seleccionar 'Otro')")]
        public int ID_MEDICAMENTO { get; set; }

        [Required(ErrorMessage = "Si no recetó nada, detallar aquí")]
        public string CICLO_CONSUMO { get; set; }

        [Required(ErrorMessage = "* Elija una vía de administración")]
        public string VIA_ADMI { get; set; }

        [Required(ErrorMessage = "* Si no hay indicaciones adicionales, detallar aquí")]
        public string INSTRUCCIONES_AD { get; set; }
    }
}