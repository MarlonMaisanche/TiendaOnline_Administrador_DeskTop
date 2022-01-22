using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Norah_API.Models.Entidad
{
    public class DetalleProductoEntidad
    {
        public int ID_DETALLE { get; set; }
        public int ID_PROD_PER { get; set; }
        public string TITULO { get; set; }
        public string CONTENIDO { get; set; }
    }
}