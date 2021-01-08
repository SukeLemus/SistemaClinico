using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaClinico.Models
{

    public class modelosjuntos
    {
        public IPagedList<SistemaClinico.Models.EnfermedadSintoma> enfs { get; set; }
        public EnfermedadSintoma enfs2 { get; set; }
    }
}