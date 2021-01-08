using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaClinico.Models
{
    public class EnfermedadSintoma
    {
       
        public int ID_ENF_SINTOMAS { get; set; }
        public int ID_ENFERMEDAD { get; set; }
        public int ID_SINTOMA { get; set; }
        
    }

 
}