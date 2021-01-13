using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaClinico.Models
{
    public class UsuarioPersonal
    {
        public int ID_PERSONAL { get; set; }


        [Required(ErrorMessage = "* El Nombre es obligatorio")]
        public String NOMBRES { get; set; }


        [Required(ErrorMessage = "* El Apellido es obligatorio")]
        public String APELLIDOS { get; set; }

        [Required(ErrorMessage = "* El DUI es obligatorio")]
        [MinLength(9)]
        [MaxLength(9)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "* Solo se permiten números.")]
        public String DUI { get; set; }

        [Required(ErrorMessage = "* El NIT es obligatorio")]
        [MinLength(14)]
        [MaxLength(14)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "* Solo se permiten números.")]
        public String NIT { get; set; }


        [Required(ErrorMessage = "* Elija su género")]
        public String GENERO { get; set; }


        //public String FECHA_NACIMIENTO { get; set; }


        [Required(ErrorMessage = "* El Departamento es obligatorio")]
        public int ID_DEPARTAMENTO { get; set; }


        [Required(ErrorMessage = "* El Teléfono es obligatorio")]
        [Phone]
        [MinLength(8)]
        [MaxLength(8)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "* Solo se permiten números.")]
        public String TELEFONO { get; set; }


        [Required(ErrorMessage = "* El Rol es obligatorio")]
        public int ID_ROL { get; set; }


        [Required(ErrorMessage = "* El e-mail es obligatorio")]
        [EmailAddress]
        public String CORREO { get; set; }


        [Required(ErrorMessage = "* El Estado es obligatorio")]
        public String ESTADO { get; set; }


        [Required(ErrorMessage = "* El Municipio es obligatorio")]
        public int ID_DIRECCION { get; set; }


        [Required(ErrorMessage = "* La dirección de residencia es obligatoria")]
        public String DIRECCION_COM { get; set; }


        [Required(ErrorMessage = "* Elija un Consultorio")]
        public int ID_CONSULTORIO { get; set; }


        [Required(ErrorMessage = "* El Usuario es obligatorio")]
        public String USUARIO { get; set; }


        [Required(ErrorMessage = "*La Contraseña es obligatoria")]
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

    public enum GENEROPersonal
    {
        Femenino,
        Masculino
    }

    public enum EstadoPersonal
    {
        Activo,
        Inacti
    }

    public class DireccionesPersonal
    {
        public int ID { get; set; }
        public string Municipio { get; set; }
        public IEnumerable<SelectListItem> ListaDirec { get; set; }
    }
}