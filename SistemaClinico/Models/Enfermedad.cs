using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaClinico.Models
{
    public class Enfermedad
    {
        public int id { get; set; }
        public String nombre_enfermedad { get; set; }
        public String descripcion { get; set; }
    }
}