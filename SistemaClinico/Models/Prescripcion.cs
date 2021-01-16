using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaClinico.Models
{
    public class Prescripcion
    {
        public int ID { get; set; }
        public int ID_CONSULTA { get; set; }
        public int ID_MEDICAMENTO { get; set; }
        public string CICLO_CONSUMO { get; set; }
        public string VIA_ADMI { get; set; }
        public string INSTRUCCIONES_AD { get; set; }
    }
}