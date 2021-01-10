using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaClinico.Models
{
    public class UsuarioPersonal
    {
        public int id { get; set; }

        public String NOMBRES { get; set; }

        public String APELLIDOS { get; set; }

        public String DUI { get; set; }

        public String NIT { get; set; }

        public String GENERO { get; set; }
        public String FECHA_NACIMIENTO { get; set; }

        public String ID_DEPARTAMENTO { get; set; }

        public String TELEFONO { get; set; }

        public int ID_ROL { get; set; }

        public String CORREO { get; set; }

        public String ESTADO { get; set; }

        public int ID_DIRECCION { get; set; }

        public String DIRECCION_COM { get; set; }

        public int ID_CONSULTORIO { get; set; }
        public String USUARIO { get; set; }

        public String PASSWORD { get; set; }
    }

    public class UsuarioPersonalJoin
    {
        public int ID_PERSONAL { get; set; }

        public String NOMBRES { get; set; }

        public String APELLIDOS { get; set; }

        public String MUNICIPIO { get; set; }

        public String NOMBRE_CONSULTORIO { get; set; }

        public String NOMBRE_DEPARTAMENTO { get; set; }
        public String NOMBRE_AREA { get; set; }

        public String NOMBRE_ROL { get; set; }
    }
}