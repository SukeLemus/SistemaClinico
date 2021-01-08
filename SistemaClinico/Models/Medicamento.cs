using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaClinico.Models
{
    public class Medicamento
    {
        public int id { get; set; }
        public String NOMBRE_MEDICAMENTO { get; set; }

        public String DESCRIPCION_MEDICAMENTO { get; set; }

        public int CANTIDAD { get; set; }
        public String PRESENTACION { get; set; }
        public double PRECIO_UNITARIO { get; set; }
        public String ESTADO { get; set; }

    }
}