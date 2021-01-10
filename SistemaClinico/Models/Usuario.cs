using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaClinico.Models
{
    public class Usuario
    {
        public int id { get; set; }
     
        public String NOMBRE { get; set; }
 
        public String APELLIDO { get; set; }

        public String DUI { get; set; }

        public String NIT { get; set; }

        public String GENERO { get; set; }

        public String TIPO_SANGRE { get; set; }

        public String TELEFONO { get; set; }

        public String CORREO { get; set; }

        public int ID_DIRECCION { get; set; }

        public String DIRECCION_COM { get; set; }

        public int ID_ROL { get; set; }

        public String ESTADO { get; set; }

        public String USUARIO { get; set; }

        public String PASSWORD { get; set; }


    }
    public class UsuarioMunicipio
    {
        public int ID_PACIENTE { get; set; }
        public int ID_DIRECCION { get; set; }

        public String NOMBRE { get; set; }

        public String APELLIDO { get; set; }

        public String TELEFONO { get; set; }

        public String MUNICIPIO { get; set; }
        public String DIRECCION_COM { get; set; }
        




    }
}