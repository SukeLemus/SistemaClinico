using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaClinico.Models
{
    public class Fracturas
    {
        public int ID { get; set; }
        public string NOMBRE_FRACTURA { get; set; }
        public string DESCRIPCION { get; set; }
    }
    public class FracturasPaciente
    {
        public int ID { get; set; }
        public int ID_PACIENTE { get; set; }
        public int ID_FRACTURAS { get; set; }
        public string NOMBRE_FRACTURA { get; set; }

    }
}