﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaClinico.Models
{
    public class Alergias
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string NOMBRE_ALERGIA { get; set; }
        [Required]
        public string DESCRIPCION { get; set; }
    }
}