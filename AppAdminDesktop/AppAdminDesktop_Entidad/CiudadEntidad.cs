using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Norah_API.Models.Entidad
{
    public class CiudadEntidad
    {
        public int ID_CIUDAD { get; set; }
        public int ID_PROVINCIA_PER { get; set; }
        public string NOM_CIUDAD { get; set; }
        public string CODIGO_POSTAL { get; set; }
    }
}