using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaClinico.Models
{
    public class Tratamiento
    {
        public int ID { get; set; }
        public int ID_PACIENTE { get; set; }
        public int ID_MEDICAMENTO { get; set; }
        public string CICLO_CONSUMO { get; set; }
        public string NOMBRE_MEDICAMENTO { get; set; }
    }
}