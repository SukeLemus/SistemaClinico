using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaClinico.Models
{
    public class Departamento
    {

        public int ID { get; set; }

        [Required]
        public String NOMBRE_DEPARTAMENTO { get; set; }

        [Required]
        public String DESCRIPCION { get; set; }
        public String ESTADO { get; set; }
        [Required]
        public int ID_AREA { get; set; }

        public String NOM { get; set; }

    }
}