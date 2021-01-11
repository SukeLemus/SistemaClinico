using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaClinico.Models
{
    public class Consultorio
    {
        public int ID { get; set; }
        public int ID_DEPARTAMENTO { get; set; }
        public string NOMBRE_CONSULTORIO { get; set; }
        public int NIVEL { get; set; }
        public string ESTADO { get; set; }
        public string NOM { get; set; }
    }
}