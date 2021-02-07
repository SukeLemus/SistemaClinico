using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaClinico.Models
{
    public class Constancia
    {
        public int ID { get; set; }
        public int ID_CONSULTA { get; set; }
    }

    public class ConstanciaPDF
    {
        public int ID_CONSTANCIA { get; set; }
        public int ID_CONSULTA { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public string FECHA { get; set; }
        public string HORA { get; set; }
        public string DIAGNOSTICO { get; set; }

        public string TELEFONO_DOCTOR { get; set; }
    }
}