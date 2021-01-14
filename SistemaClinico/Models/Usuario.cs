using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaClinico.Models
{
    public class RegistroPacienteUsuario
    {
        public int id { get; set; }

        //[Required(ErrorMessage = "mensaje personalizado")]
        [Required(ErrorMessage = "* El Nombre es obligatorio")]
        public String NOMBRE { get; set; }

        [Required(ErrorMessage = "* El Apellido es obligatorio")]
        public String APELLIDO { get; set; }

        [MinLength(9)]
        [MaxLength(9)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "* Solo se permiten números.")]
        public String DUI { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "* Solo se permiten números.")]
        [MinLength(14)]
        [MaxLength(14)]
        public String NIT { get; set; }

        [Required(ErrorMessage = "* Elija su género")]
        public String GENERO { get; set; }
        
        [Required(ErrorMessage = "* Elija su fecha de nacimiento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FECHA_NACIMIENTO { get; set; }
       
        [Required(ErrorMessage = "* El Tipo de sangre es obligatorio (si no lo sabe elija 'No lo sé')")]
        public String TIPO_SANGRE { get; set; }

        [Required(ErrorMessage = "* El Teléfono es obligatorio")]
        [Phone]
        [RegularExpression("^[0-9]*$", ErrorMessage = "* Solo se permiten números.")]
        [MinLength(8)]
        [MaxLength(8)]
        public String TELEFONO { get; set; }

        [Required(ErrorMessage = "* El e-mail es obligatorio")]
        [EmailAddress]
        public String CORREO { get; set; }

        [Required(ErrorMessage = "* El Municipio es obligatorio")]
        public int ID_DIRECCION { get; set; }

        [Required(ErrorMessage = "* la Dirección es obligatoria")]
        public String DIRECCION_COM { get; set; }

        [Required(ErrorMessage = "* El Rol es obligatorio")]
        public int ID_ROL { get; set; }

        [Required(ErrorMessage = "* El Estado es obligatorio")]
        public String ESTADO { get; set; }

        [Required(ErrorMessage = "* El Usuario es obligatorio")]
        public String USUARIO { get; set; }

        [Required(ErrorMessage = "* La Contraseña es obligatoria")]
        public String PASSWORD { get; set; }

    }

    public class DireccionesUsuario
    {
        public int ID { get; set; }
        public string Municipio { get; set; }
        public IEnumerable<SelectListItem> ListaDirec { get; set; }
    }

    public enum GENEROUsuario
    {
        Femenino,
        Masculino
    }



    public enum TIPO_SANGREUsuario
    {
       
        O_negativo,
        O_positivo,
        A_negativo,
        B_negativo,
        B_positivo,
        AB_negativo,
        AB_positivo
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

}