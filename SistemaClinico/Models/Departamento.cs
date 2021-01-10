using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaClinico.Models
{
    public class Departamento
    {

        public int ID { get; set; }

        public String NOMBRE_DEPARTAMENTO { get; set; }
  
        public String DESCRIPCION { get; set; }
        public String ESTADO { get; set; }
       
        public int ID_AREA { get; set; }

        public String NOM { get; set; }

    }
}