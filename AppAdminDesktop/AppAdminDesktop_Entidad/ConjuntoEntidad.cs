using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Norah_API.Models.Entidad
{
    public class ConjuntoEntidad
    {
        public int ID_CONJUNTO { get; set; }
        public string NOM_CONJUNTO { get; set; }
        public double PRECIO_TOTAL { get; set; }
        public double PRECIO_PORMO { get; set; }
        public List<ProductoEntidad> PRODUCTOS{ get; set; }

    }
}